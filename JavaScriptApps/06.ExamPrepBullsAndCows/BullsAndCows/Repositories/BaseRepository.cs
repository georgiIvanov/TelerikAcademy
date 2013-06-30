using BullsAndCows.Data;
using BullsAndCows.Models;
using System;
using System.Linq;

namespace BullsAndCows.Repository
{
    public abstract class BaseRepository
    {
        protected const int Sha1CodeLength = 40;
        protected const int UserNumberLength = 4;

        protected const string GameStatusOpen = "open";
        protected const string GameStatusFull = "full";
        protected const string GameStatusInProgress = "in progress";
        protected const string GameStatusFinished = "finished";

        protected const string MessageStateUnread = "unread";
        protected const string MessageStateRead = "read";
        protected static Random rand = new Random();

        protected const string MessageTypeGameJoined = "game-joined";
        protected const string MessageTypeGameStarted = "game-started";
        protected const string MessageTypeGameFinished = "game-finished";
        protected const string MessageTypeGuessMade = "guess-made";

        protected static void ValidateUserInGame(Game game, User user)
        {
            if (game.RedUser != user && game.BlueUser != user)
            {
                throw new ServerErrorException("User not in game", "INV_GAME_USR");
            }
            if (game.UserInTurn != user.Id)
            {
                throw new ServerErrorException("Not your turn", "INV_OP_TURN");
            }
        }

        protected static void ValidateUserNumber(int number)
        {
            var numberString = number.ToString();
            if (numberString.Length != UserNumberLength || numberString.Any(digit => !char.IsDigit(digit) || digit == '0'))
            {
                throw new ServerErrorException("Invalid Number", "ERR_INV_NUM");
            }
            for (var i = 0; i < numberString.Length - 1; i++)
            {
                for (int j = i + 1; j < numberString.Length; j++)
                {
                    if (numberString[i] == numberString[j])
                    {
                        throw new ServerErrorException("Invalid Number", "ERR_INV_NUM");
                    }
                }
            }
        }

        protected static User GetUser(int userId, BullsAndCowsEntities context)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ServerErrorException("Invalid user", "ERR_INV_USR");
            }
            return user;
        }

        protected static Game GetGame(int gameId, BullsAndCowsEntities context)
        {
            var game = context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
            {
                throw new ServerErrorException("Invalid game", "ERR_INV_GAME");
            }
            return game;
        }

        protected static void SendMessage(string messageText, User toUser, Game game, MessageType messageType, BullsAndCowsEntities context)
        {
            MessageState unreadMessageState = context.MessageStates.First(ms => ms.State == MessageStateUnread);
            var message = new Message()
            {
                Text = messageText,
                Game = game,
                User = toUser,
                MessageState = unreadMessageState,
                MessageType = messageType
            };

            context.Messages.Add(message);
        }
    }
}