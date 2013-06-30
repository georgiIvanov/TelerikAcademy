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
    public class GuessController:BaseApiController
    {
        [HttpPost]
        [ActionName("make")]
        public HttpResponseMessage MakeGuess(string sessionKey, [FromBody] GuessModel guess)
        {
            var response = this.PerformOperation(() =>
            {
                var userId = UsersRepository.LoginUser(sessionKey);
                GuessRepository.MakeGuess(userId, guess);
            });
            return response;
        }
    }
}