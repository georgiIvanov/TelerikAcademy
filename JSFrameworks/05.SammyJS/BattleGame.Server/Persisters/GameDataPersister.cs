using BattleGame.Server.Data;
using BattleGame.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Server.Persisters
{
    public class GameDataPersister : BattleGame.Server.Persisters.BaseDataPersister
    {
        private const string WarriorType = "warrior";
        private const string RangerType = "ranger";

        private const int RedWarriorsPositionX = 6;
        private const int RedRangerPositionX = 8;
        private const int BlueWarriorsPositionX = 2;
        private const int BlueRangerPositionX = 0;
        private static readonly int[] WarriorsPositionsY = { 0, 2, 4, 6, 8 };
        private static readonly int[] RangersPositionsY = { 1, 3, 5, 7 };

        private const string UnitAttackMode = "attack";
        private const string UnitDefendMode = "defend";

        private const int MinTitleLength = 6;
        private const int MaxTitleLength = 40;
        private const string ValidTitleChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";

        private static IEnumerable<Unit> GenerateUnits(int warriorPositionX, int rangersPositionX, UnitType warriorType, UnitType rangerType)
        {
            List<Unit> units = new List<Unit>();
            for (var i = 0; i < WarriorsPositionsY.Length; i++)
            {
                var warriorUnit = UnitFactory.GetUnit(warriorType, warriorPositionX, WarriorsPositionsY[i]);
                units.Add(warriorUnit);
            }
            for (var i = 0; i < RangersPositionsY.Length; i++)
            {
                var rangerUnit = UnitFactory.GetUnit(rangerType, rangersPositionX, RangersPositionsY[i]);
                units.Add(rangerUnit);
            }
            return units;
        }

        private static void ValidateGameTitle(string title)
        {
            if (title == null || title.Length < MinTitleLength || title.Length > MaxTitleLength)
            {
                throw new ServerErrorException(string.Format("The title of the game should be between {0} and {1} characters", MinTitleLength, MaxTitleLength), "INV_TITLE_LEN");
            }
            else if (title.Any(ch => !ValidTitleChars.Contains(ch)))
            {
                throw new ServerErrorException("The title of the game contains invalid characters", "INV_TITLE_CHARS");
            }
        }

        private static void ValidateGamePassword(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ServerErrorException("Invalid game password", "INV_GAME_PASS");
            }
        }

        /* public members */

        public static void CreateGame(int userId, string title, string password)
        {
            ValidateGameTitle(title);
            if (password != null)
            {
                ValidateGamePassword(password);
            }

            var context = new BattleGameEntities();
            using (context)
            {
                var user = GetUser(userId, context);

                var game = new Game()
                {
                    Title = title,
                    Password = password,
                    Status = context.Statuses.First(st => st.Value == GameStatusOpen),
                    RedUser = user
                };
                context.Games.Add(game);

                context.SaveChanges();
            }
        }

        public static void JoinGame(int userId, int gameId, string password)
        {
            if (password != null)
            {
                ValidateGamePassword(password);
            }
            var context = new BattleGameEntities();
            using (context)
            {
                var user = GetUser(userId, context);

                var game = context.Games.FirstOrDefault(g => g.Id == gameId);
                if (game == null)
                {
                    throw new ServerErrorException("No such game", "ERR_INV_GAME");
                }

                ValidateOpenGameStatus(game, context);

                if (game.Password != null && game.Password != password)
                {
                    throw new ServerErrorException("Invalid game password", "INV_GAME_PASS");
                }

                game.BlueUser = user;

                string messageText = string.Format("{0} just joined your game {1}", game.BlueUser.Nickname, game.Title);
                UserMessagesType gameJoinedUserMessageType = context.UserMessagesTypes.First(mt => mt.Type == UserMessageTypeGameJoined);
                SendMessage(messageText, game.RedUser, game, gameJoinedUserMessageType, context);

                var fullGameStatus = context.Statuses.First(st => st.Value == GameStatusFull);
                game.Status = fullGameStatus;

                context.SaveChanges();
            }
        }

        public static void StartGame(int gameId)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                var game = GetGame(gameId, context);
                if (game.Status.Value != GameStatusFull)
                {
                    throw new ServerErrorException("Nobody has joined this game", "INV_GAME_STATE");
                }

                UnitType warriorType = context.UnitTypes.First(type => type.Value == WarriorType);
                UnitType rangerType = context.UnitTypes.First(type => type.Value == RangerType);
                var redUnits = GenerateUnits(RedWarriorsPositionX, RedRangerPositionX, warriorType, rangerType);

                var attackMode = context.Modes.First(m => m.Value == UnitAttackMode);

                foreach (var unit in redUnits)
                {
                    unit.Mode = attackMode;
                    unit.User = game.RedUser;
                    game.Units.Add(unit);
                }

                var blueUnits = GenerateUnits(BlueWarriorsPositionX, BlueRangerPositionX, warriorType, rangerType);
                foreach (var unit in blueUnits)
                {
                    unit.Mode = attackMode;
                    unit.User = game.BlueUser;
                    game.Units.Add(unit);
                }

                game.Status = context.Statuses.First(st => st.Value == GameStatusInProgress);

                game.Turn = 0;
                var userInTurn = (rand.Next() % 2 == 0) ? game.RedUser : game.BlueUser;
                game.UserInTurn = userInTurn.Id;

                var gameStartedMessageText = string.Format("{0} just started game {1}", game.RedUser.Nickname, game.Title);
                var gameStartedMessageType = context.UserMessagesTypes.First(mt => mt.Type == UserMessageTypeGameStarted);
                SendMessage(gameStartedMessageText, game.BlueUser, game, gameStartedMessageType, context);

                var gameMoveMessageText = string.Format("It is your turn in game {0}", game.Title);
                var gameMoveMessageType = context.UserMessagesTypes.First(mt => mt.Type == UserMessageTypeGameMove);
                SendMessage(gameMoveMessageText, userInTurn, game, gameMoveMessageType, context);

                context.SaveChanges();
            }
        }

        public static IEnumerable<OpenGameModel> GetOpenGames(int userId)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                var user = GetUser(userId, context);
                var openStatus = context.Statuses.FirstOrDefault(st => st.Value == GameStatusOpen);
                IEnumerable<OpenGameModel> openGames;
                if (openStatus.Games.Any())
                {
                    openGames =
                               from game in openStatus.Games
                               where game.RedUser != user
                               select new OpenGameModel()
                               {
                                   Id = (int)game.Id,
                                   Title = game.Title,
                                   Creator = game.RedUser.Nickname
                               };
                }
                else
                {
                    openGames = new List<OpenGameModel>();
                }
                return openGames.ToList();
            }
        }

        public static IEnumerable<ActiveGameModel> GetActiveGames(int userId)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                var user = GetUser(userId, context);
                IEnumerable<ActiveGameModel> activeGameModels;
                if (user.GamesCreated.Any() || user.GamesJoined.Any())
                {
                    var gamesList = context.Games.ToList();

                    activeGameModels =
                                      from game in gamesList
                                      where (game.BlueUser == user || game.RedUser == user) &&
                                      (game.Status.Value == GameStatusInProgress || game.Status.Value == GameStatusFull || game.Status.Value == GameStatusOpen)
                                      select new ActiveGameModel()
                                      {
                                          Id = (int)game.Id,
                                          Creator = game.RedUser.Nickname,
                                          Status = game.Status.Value,
                                          Title = game.Title
                                      };
                }
                else
                {
                    activeGameModels = new List<ActiveGameModel>();
                }
                return activeGameModels.ToList();
            }
        }

        public static BattleFieldModel GetBattleField(int gameId)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                Game game = GetGame(gameId, context);
                ValidateGameInProgressStatus(game, context);

                var redUnitModels = GetUserUnits(game.RedUser, game);
                var blueUnitModels = GetUserUnits(game.BlueUser, game);

                var gameField = new BattleFieldModel()
                {
                    GameId = (int)game.Id,
                    Title = game.Title,
                    Red = new UserInGameModel()
                    {
                        Nickname = game.RedUser.Nickname,
                        Units = redUnitModels
                    },
                    Blue = new UserInGameModel()
                    {
                        Nickname = game.BlueUser.Nickname,
                        Units = blueUnitModels
                    },
                    Turn = game.Turn,
                    PlayerInTurn = (game.UserInTurn == game.RedUser.Id) ? "red" : "blue"
                };
                return gameField;
            }
        }
    }
}