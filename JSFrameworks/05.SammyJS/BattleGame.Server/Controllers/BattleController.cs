using BattleGame.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BattleGame.Server.Persisters;

namespace BattleGame.Server.Controllers
{
    public class BattleController : BaseApiController
    {
        [HttpPost]
        [ActionName("move")]
        public HttpResponseMessage PerformMove(string sessionKey, int gameId, [FromBody]
                                               MoveModel move)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                BattleDataPersister.PerformMove(userId, gameId, move.UnitId, move.Position.X, move.Position.Y);
                return GameDataPersister.GetBattleField(gameId);
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("attack")]
        public HttpResponseMessage PerformAttack(string sessionKey, int gameId, [FromBody]
                                                 MoveModel move)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                BattleDataPersister.PerformAttack(userId, gameId, move.UnitId, move.Position.X, move.Position.Y);
                return GameDataPersister.GetBattleField(gameId);
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("defend")]
        public HttpResponseMessage PerformDefend(string sessionKey, int gameId, [FromBody]
                                                 int unitId)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                BattleDataPersister.PerformDefend(userId, gameId, unitId);
                return GameDataPersister.GetBattleField(gameId);
            });
            return responseMsg;
        }
    }
}