using BullsAndCows.Models;
using BullsAndCows.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BullsAndCows.Controllers
{
    public class GameController : BaseApiController
    {
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateGame(string sessionKey, [FromBody] CreateGameModel gameModel)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                GamesRepository.CreateGame(userId, gameModel);
            });
            return response;
        }

        [HttpPost]
        [ActionName("join")]
        public HttpResponseMessage JoinGame(string sessionKey, [FromBody] JoinGameModel gameModel)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                GamesRepository.JoinGame(userId, gameModel);
            });
            return response;
        }

        [HttpGet]
        [ActionName("start")]
        public HttpResponseMessage StartGame(string sessionKey, int gameId)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                GamesRepository.StartGame(userId, gameId);
            });
            return response;
        }

        [HttpGet]
        [ActionName("open")]
        public HttpResponseMessage GetOpenGames(string sessionKey)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                var openGames = GamesRepository.GetOpenGames(userId);
                return openGames;
            });
            return response;
        }

        [HttpGet]
        [ActionName("my-active")]
        public HttpResponseMessage GetMyActiveGames(string sessionKey)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                var activeGames = GamesRepository.GetActiveGames(userId);
                return activeGames;
            });
            return response;
        }

        [HttpGet]
        [ActionName("state")]
        public HttpResponseMessage GetAllGameGuesses(string sessionKey, int gameId)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                var gameState = GamesRepository.GetGameState(gameId, userId);
                return gameState;
            });
            return response;
        }
    }
}
