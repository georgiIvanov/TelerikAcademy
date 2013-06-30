using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using BullsAndCows.Models;
using BullsAndCows.Repository;

namespace BullsAndCows.Controllers
{
    public class UserController : BaseApiController
    {
        /*
{
   "username": "Dodo",
    "nickname": "Doncho Minkov",
   "authCode": "6fa9133efe05348e430bd5a4585b595f0cb6cba3"
}
       */
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisterModel user)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UsersRepository.CreateUser(user.Username, user.Nickname, user.AuthCode);
                string nickname = string.Empty;
                var sessionKey = UsersRepository.LoginUser(user.Username, user.AuthCode, out nickname);
                return new UserLoggedModel()
                {
                    Nickname = nickname,
                    SessionKey = sessionKey
                };
            });
            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserLoginModel user)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                string nickname = string.Empty;
                var sessionKey = UsersRepository.LoginUser(user.Username, user.AuthCode, out nickname);
                return new UserLoggedModel()
                {
                    Nickname = nickname,
                    SessionKey = sessionKey
                };
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UsersRepository.LogoutUser(sessionKey);
            });
            return responseMsg;
        }

        [HttpGet]
        [ActionName("scores")]
        public HttpResponseMessage GetAllUsers(string sessionKey)
        {
            var responseMsg = this.PerformOperation(() =>
            {
                UsersRepository.LoginUser(sessionKey);
                IEnumerable<UserScore> users = UsersRepository.GetAllUsers();

                return users;
            });
            return responseMsg;
        }
    }
}