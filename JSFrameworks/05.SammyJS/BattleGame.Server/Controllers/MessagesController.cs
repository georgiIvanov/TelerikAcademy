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
    public class MessagesController : BaseApiController
    {
        /*
{
   "username": "Dodo",
    "nickname": "Doncho Minkov",
   "authCode": "96b828b4cc79f50bf8faef6e7b4a1dcfb356dea6"
}
       */

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAllMessages(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                var messages = MessagesDataPersister.GetAllMessages(userId);
                return messages;

            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("unread")]
        public HttpResponseMessage GetUnreadMessages(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                var userId = UserDataPersister.LoginUser(sessionKey);
                var messages = MessagesDataPersister.GetUnreadMessages(userId);
                return messages;
            });
            return responseMsg;
        }
    }
}