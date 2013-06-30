using BullsAndCows.Data;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Repository
{
    public class GuessRepository : BaseRepository
    {
        private const string MessageTextGuessMade = "{0} made a guess \"{1}\" in game {2}";
        private const string MessageTextGameFinishedWinner = "You won the game {0} against {1} with {2} guesses";
        private const string MessageTextGameFinishedLoser = "You were beaten by {0} in game {1}";

        private static string GetOtherUserNumber(Game game, User user)
        {
            if (game.RedUser == user)
            {
                return game.BlueUserNumber.ToString();
            }
            else
            {
                return game.RedUserNumber.ToString();
            }
        }

        private static void CountBullsAndCows(string guessNumber, string otherUserNumber, out int bullsCount, out int cowsCount)
        {
            bullsCount = 0;
            cowsCount = 0;

            for (int i = 0; i < guessNumber.Length; i++)
            {
                var guessDigit = guessNumber[i];
                for (int j = 0; j < otherUserNumber.Length; j++)
                {
                    var otherDigit = otherUserNumber[j];
                    if (guessDigit == otherDigit)
                    {
                        if (i == j)
                        {
                            bullsCount++;
                        }
                        else
                        {
                            cowsCount++;
                        }
                    }
                }
            }
        }

        private static void FinishGame(User user, User otherUser, Game game, BullsAndCowsEntities context)
        {
            game.GameStatus = context.GameStatuses.First(st => st.Status == GameStatusFinished);

            var guessesMadeCount = game.Guesses.Count(g => g.User == user);
            var score = new Score()
            {
                User = user,
                Value = 1000 / guessesMadeCount
            };

            context.Scores.Add(score);

            //send msg
            MessageType gameFinishedMessageType = context.MessageTypes.First(mt => mt.Type == MessageTypeGameFinished);

            string messageTextWinner = string.Format(MessageTextGameFinishedWinner, game.Title, otherUser.Nickname, guessesMadeCount);
            SendMessage(messageTextWinner, user, game, gameFinishedMessageType, context);

            string messageTextLoser = string.Format(MessageTextGameFinishedLoser, user.Nickname, game.Title);
            SendMessage(messageTextLoser, otherUser, game, gameFinishedMessageType, context);
        }

        /* public members */

        public static void MakeGuess(int userId, GuessModel guessModel)
        {
            ValidateUserNumber(guessModel.Number);
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = GetUser(userId, context);
                var game = GetGame(guessModel.GameId, context);

                if (game.GameStatus != context.GameStatuses.First((st) => st.Status == GameStatusInProgress))
                {
                    throw new ServerErrorException("Game is not in progress", "INV_OP_GAME_STAT");
                }

                ValidateUserInGame(game, user);

                var guessNumber = guessModel.Number.ToString();
                string otherUserNumber = GetOtherUserNumber(game, user);

                int bullsCount, cowsCount;
                CountBullsAndCows(guessNumber, otherUserNumber, out bullsCount, out cowsCount);

                var guess = new Guess()
                {
                    Bulls = bullsCount,
                    Cows = cowsCount,
                    Game = game,
                    Number = guessModel.Number,
                    User = user
                };
                context.Guesses.Add(guess);

                var otherUser = (game.RedUser == user) ? game.BlueUser : game.RedUser;

                if (bullsCount == UserNumberLength)
                {
                    FinishGame(user, otherUser, game, context);
                }
                else
                {
                    game.UserInTurn = otherUser.Id;

                    MessageType guessMadeMessageType = context.MessageTypes.First(mt => mt.Type == MessageTypeGuessMade);
                    string messageText = string.Format(MessageTextGuessMade, user.Nickname, guessNumber, game.Title);
                    SendMessage(messageText, otherUser, game, guessMadeMessageType, context);
                }
                context.SaveChanges();
            }
        }
    }
}