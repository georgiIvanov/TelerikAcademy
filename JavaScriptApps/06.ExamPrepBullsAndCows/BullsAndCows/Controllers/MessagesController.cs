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
    public class MessagesController : BaseApiController
    {
        [HttpGet]
        [ActionName("unread")]
        public HttpResponseMessage GetUnreadMessages(string sessionKey)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                var messageModels = MessagesRepository.GetUnreadMessages(userId);
                return messageModels;
            });
            return response;
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetAllMessages(string sessionKey)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                var messageModels = MessagesRepository.GetAllMessages(userId);
                return messageModels;
            });
            return response;
        }

    }
}
