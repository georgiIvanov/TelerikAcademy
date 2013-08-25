using BattleGame.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGame.Server.Models;

namespace BattleGame.Server.Persisters
{
    public class BaseDataPersister
    {
        protected const int Sha1CodeLength = 40;

        protected const string GameStatusOpen = "open";
        protected const string GameStatusFull = "full";
        protected const string GameStatusInProgress = "in-progress";
        protected const string GameStatusFinished = "finished";

        protected static Random rand = new Random();
        protected const string MessageStateUnread = "unread";

        protected const string UserMessageTypeGameStarted = "game-started";
        protected const string UserMessageTypeGameJoined = "game-joined";
        protected const string UserMessageTypeGameFinished = "game-finished";
        protected const string UserMessageTypeGameMove = "game-move";

        protected static User GetUser(int userId, BattleGameEntities context)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ServerErrorException("Invalid user", "ERR_INV_USR");
            }
            return user;
        }

        protected static Game GetGame(int gameId, BattleGameEntities context)
        {
            var game = context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
            {
                throw new ServerErrorException("No such game", "ERR_INV_GAME");
            }
            return game;
        }

        protected static void SendMessage(string text, User toUser, Game game, UserMessagesType msgType, BattleGameEntities context)
        {
            toUser.UserMessages.Add(new UserMessage()
            {
                Game = game,
                MessageState = context.MessageStates.First(ms => ms.State == MessageStateUnread),
                UserMessagesType = msgType,
                Text = text
            });
        }

        protected static void ValidateOpenGameStatus(Game game, BattleGameEntities context)
        {
            if (game.Status.Value == GameStatusInProgress)
            {
                throw new ServerErrorException("Game has already been started", "INV_GAME_STATE");
            }
            else if (game.Status.Value == GameStatusFinished)
            {
                throw new ServerErrorException("Game is already finished", "INV_GAME_STATE");
            }
            else if (game.Status.Value == GameStatusFull)
            {
                throw new ServerErrorException("Game is not started yet", "INV_GAME_STATE");
            }
        }

        protected static void ValidateGameInProgressStatus(Game game, BattleGameEntities context)
        {
            if (game.Status.Value == GameStatusOpen)
            {
                throw new ServerErrorException("Game not yet full", "INV_GAME_STATE");
            }
            else if (game.Status.Value == GameStatusFinished)
            {
                throw new ServerErrorException("Game is already finished", "INV_GAME_STATE");
            }
            else if (game.Status.Value == GameStatusFull)
            {
                throw new ServerErrorException("Game is not started yet", "INV_GAME_STATE");
            }
        }

        protected static IEnumerable<UnitModel> GetUserUnits(User owner, Game game)
        {
            var unitModels =
                            from unit in game.Units
                            where unit.HitPoints > 0 && unit.User == owner
                            select new UnitModel()
                            {
                                Id = unit.Id,
                                Owner = (game.RedUser == unit.User) ? "red" : "blue",
                                Type = unit.UnitType.Value,
                                Mode = unit.Mode.Value,
                                Attack = (int)unit.Attack,
                                Armor = (int)unit.Armor,
                                Range = (int)unit.Range,
                                Speed = (int)unit.Speed,
                                HitPoints = (int)unit.HitPoints,
                                Position = new PositionModel()
                                {
                                    X = unit.PositionX,
                                    Y = unit.PositionY
                                }
                            };
            return unitModels.ToList();
        }
    }
}