using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BattleGame.Server.Models;
using System.Text;
using BattleGame.Server.Persisters;

namespace BattleGame.Server.Controllers
{
    public class GameController : BaseApiController
    {
        /*
        {
        "username": "Dodo",        
        "nickname": "Doncho Minkov",
        "authCode": "96b828b4cc79f50bf8faef6e7b4a1dcfb356dea6"
        }
        */
        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage CreateGame(string sessionKey, [FromBody]
                                              GameModel gameModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                GameDataPersister.CreateGame(userId, gameModel.Title, gameModel.Password);
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("join")]
        public HttpResponseMessage JoinGame(string sessionKey, [FromBody]
                                            GameModel gameModel)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                GameDataPersister.JoinGame(userId, gameModel.Id, gameModel.Password);
            });
            return responseMsg;
        }

        [HttpPut]
        [ActionName("start")]
        public HttpResponseMessage StartGame(string sessionKey, int gameId)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                GameDataPersister.StartGame(gameId);
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("open")]
        public HttpResponseMessage GetOpenGames(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                var games = GameDataPersister.GetOpenGames(userId);
                return games;
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("my-active")]
        public HttpResponseMessage GetActiveGames(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                IEnumerable<OpenGameModel> games = GameDataPersister.GetActiveGames(userId);
                return games;
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("field")]
        public HttpResponseMessage GetBattleField(string sessionKey, int gameId)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UserDataPersister.LoginUser(sessionKey);

                BattleFieldModel gameField = GameDataPersister.GetBattleField(gameId);

                return gameField;
            });
            return responseMsg;
        }
    }
}