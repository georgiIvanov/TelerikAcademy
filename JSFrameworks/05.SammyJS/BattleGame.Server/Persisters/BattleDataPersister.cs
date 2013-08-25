using BattleGame.Server.Data;
using BattleGame.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleGame.Server.Persisters
{
    public class BattleDataPersister : BaseDataPersister
    {
        private const string UnitModeDefend = "defend";
        private const string UnitModeAttack = "attack";
        private const string GameMoveMessageType = "game-move";
        private const string GameMoveMessageText = "{0} made their move in game {1}";

        protected const int BattleFieldMaxX = 8;
        protected const int BattleFieldMaxY = 8;


        private static Unit GetUnit(int unitId, BattleGameEntities context)
        {
            var unit = context.Units.FirstOrDefault(u => u.Id == unitId && u.HitPoints > 0);
            if (unit == null)
            {
                throw new ServerErrorException("No such unit", "ERR_INV_UNIT");
            }
            return unit;
        }

        private static void ValidateUnitMovePosition(Game game, Unit unit, long toX, long toY)
        {
            if (toX < 0 || toX > BattleFieldMaxX || toY < 0 || toY > BattleFieldMaxY)
            {
                throw new ServerErrorException("Units cannot go outside of the battle field", "INV_UNIT_POS");
            }
            var diffX = Math.Abs(unit.PositionX - toX);
            var diffY = Math.Abs(unit.PositionY - toY);
            if (diffX + diffY > unit.Speed)
            {
                throw new ServerErrorException("Unit cannot move to that position", "INV_UNIT_POS");
            }
            if (game.Units.Any(u => u.HitPoints > 0 && u.PositionX == toX && u.PositionY == toY))
            {
                throw new ServerErrorException("Position is already occupied", "INV_UNIT_POS");
            }
        }

        private static void ValidateUnitAttackPosition(Game game, Unit unit, User owner, long toX, long toY)
        {
            if (toX < 0 || toX > BattleFieldMaxX || toY < 0 || toY > BattleFieldMaxY)
            {
                throw new ServerErrorException("Units cannot attack outside of the battle field", "INV_ATT_POS");
            }
            var diffX = Math.Abs(unit.PositionX - toX);
            var diffY = Math.Abs(unit.PositionY - toY);
            if (diffX + diffY > unit.Range)
            {
                throw new ServerErrorException("The Unit cannot attack that far", "INV_ATT_RANGE");
            }
        }

        private static void ValidateUserUnitInGame(User user, Unit unit, Game game)
        {
            if (game.UserInTurn != user.Id)
            {
                throw new ServerErrorException("It is not your turn", "INV_USR_TURN");
            }

            if (!user.Units.Any(u => u == unit))
            {
                throw new ServerErrorException("This is not your unit", "INV_USR_UNIT");
            }

            if (!game.Units.Any(u => u == unit))
            {
                throw new ServerErrorException("No such unit in the game", "INV_USR_GAME");
            }
        }

        private static Unit GetAttackedUnit(User owner, Game game, long toX, long toY)
        {
            var attackedUnit = game.Units.FirstOrDefault(u => u.PositionX == toX && u.PositionY == toY && u.HitPoints > 0);
            if (attackedUnit == null)
            {
                throw new ServerErrorException("Nothing to attack on that position", "INV_ATT_EMPTY");
            }
            else if (attackedUnit.User == owner)
            {
                throw new ServerErrorException("Unit cannot attack allied units", "INV_ATT_ALLY");
            }
            return attackedUnit;
        }

        /* public members */

        public static void PerformMove(int userId, int gameId, int unitId, long toX, long toY)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                Game game = GetGame(gameId, context);
                ValidateGameInProgressStatus(game, context);

                User user = GetUser(userId, context);
                Unit unit = GetUnit(unitId, context);

                ValidateUserUnitInGame(user, unit, game);

                ValidateUnitMovePosition(game, unit, toX, toY);

                unit.Mode = context.Modes.First(m => m.Value == UnitModeAttack);
                unit.PositionX = toX;
                unit.PositionY = toY;

                var otherUser = (game.RedUser == user) ? game.BlueUser : game.RedUser;

                game.Turn++;
                game.UserInTurn = otherUser.Id;

                var messageText = string.Format(GameMoveMessageText, user.Nickname, game.Title);
                var gameMoveUserMessagesType = context.UserMessagesTypes.First(mt => mt.Type == GameMoveMessageType);
                SendMessage(messageText, otherUser, game, gameMoveUserMessagesType, context);
                context.SaveChanges();
            }
        }

        public static void PerformAttack(int userId, int gameId, int unitId, long toX, long toY)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                var game = GetGame(gameId, context);
                ValidateGameInProgressStatus(game, context);

                User user = GetUser(userId, context);
                Unit unit = GetUnit(unitId, context);

                ValidateUserUnitInGame(user, unit, game);

                ValidateUnitAttackPosition(game, unit, user, toX, toY);

                Unit attackedUnit = GetAttackedUnit(user, game, toX, toY);
                var attackedUnitArmor = attackedUnit.Armor;
                if (attackedUnit.Mode.Value == UnitModeDefend)
                {
                    attackedUnitArmor *= 2;
                }

                unit.Mode = context.Modes.First(m => m.Value == UnitModeAttack);
                var dmgTaken = unit.Attack - attackedUnitArmor;
                if (dmgTaken > 0)
                {
                    attackedUnit.HitPoints -= dmgTaken;
                }
                context.SaveChanges();

                var otherUser = (game.RedUser == user) ? game.BlueUser : game.RedUser;

                game.Turn++;

                if (game.Units.Any(u => u.User == otherUser && u.HitPoints > 0))
                {
                    game.UserInTurn = otherUser.Id;
                    var messageText = string.Format(GameMoveMessageText, user.Nickname, game.Title);
                    var gameMoveUserMessagesType = context.UserMessagesTypes.First(mt => mt.Type == GameMoveMessageType);
                    SendMessage(messageText, otherUser, game, gameMoveUserMessagesType, context);
                }
                else
                {
                    var finishedGameStatus = context.Statuses.First(st => st.Value == GameStatusFinished);
                    game.Status = finishedGameStatus;

                    var finishedGameMessageType = context.UserMessagesTypes.First(umt => umt.Type == UserMessageTypeGameFinished);

                    var messageTextWinner = string.Format("You won in game {0} against {1} in {2} moves!", game.Title, otherUser.Nickname, game.Turn);
                    SendMessage(messageTextWinner, user, game, finishedGameMessageType, context);

                    var messageTextLoser = string.Format("You were beaten in game {0} by {1}", game.Title, user.Nickname);
                    SendMessage(messageTextLoser, otherUser, game, finishedGameMessageType, context);

                    var score = game.Units.Where(u => u.User == user && u.HitPoints > 0).Sum(u => u.HitPoints);
                    user.Scores.Add(new Score()
                    {
                        Value = score
                    });
                }

                context.SaveChanges();
            }
        }

        public static void PerformDefend(int userId, int gameId, int unitId)
        {
            var context = new BattleGameEntities();

            using (context)
            {
                var game = GetGame(gameId, context);
                ValidateGameInProgressStatus(game, context);

                var user = GetUser(userId, context);
                var unit = GetUnit(unitId, context);
                ValidateUserUnitInGame(user, unit, game);

                unit.Mode = context.Modes.First(m => m.Value == UnitModeDefend);
                
                var otherUser = (game.RedUser == user) ? game.BlueUser : game.RedUser;
                game.Turn++;
                game.UserInTurn = otherUser.Id;

                context.SaveChanges();
            }
        }
    }
}