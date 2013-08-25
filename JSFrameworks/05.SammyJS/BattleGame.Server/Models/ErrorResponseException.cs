using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BattleGame.Server.Models
{
    public class ErrorResponseException : HttpResponseException
    {
        public ErrorResponseException(HttpResponseMessage msg) : base(msg)
        {
        }

        public ErrorResponseException(HttpStatusCode statusCode) : base(statusCode)
        {
        }
    }
}