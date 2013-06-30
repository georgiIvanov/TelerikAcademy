using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace BullsAndCows.Controllers
{
    public class BaseApiController : ApiController
    {
        private static Dictionary<string, HttpStatusCode> ErrorToStatusCodes = new Dictionary<string, HttpStatusCode>();

        static BaseApiController()
        {
            ErrorToStatusCodes["INV_GAME_USR"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_GEN_SVR"] = HttpStatusCode.InternalServerError;
            ErrorToStatusCodes["INV_OP_TURN"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_INV_NUM"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_INV_USR"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_INV_GAME"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_GAME_AUTH_LEN"] = HttpStatusCode.Unauthorized;
            ErrorToStatusCodes["ERR_GAME_STAT_FULL"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_GAME_STAT_PROG"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_GAME_STAT_FIN"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_GAME_AUTH"] = HttpStatusCode.Unauthorized;
            ErrorToStatusCodes["INV_OP_GAME_OWNER"] = HttpStatusCode.Unauthorized;
            ErrorToStatusCodes["INV_OP_GAME_STAT"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_NOT_IN_GAME"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_USRNAME_LEN"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_USRNAME_CHARS"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_NICK_LEN"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_NICK_CHARS"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["INV_USR_AUTH_LEN"] = HttpStatusCode.BadRequest;
            ErrorToStatusCodes["ERR_DUP_USR"] = HttpStatusCode.Conflict;
            ErrorToStatusCodes["ERR_DUP_NICK"] = HttpStatusCode.Conflict;
            ErrorToStatusCodes["INV_USR_AUTH"] = HttpStatusCode.BadRequest;
        }

        public BaseApiController()
        {
        }

        protected HttpResponseMessage PerformOperation(Action action)
        {
            try
            {
                action();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ServerErrorException ex)
            {
                return BuildErrorResponse(ex.Message, ex.ErrorCode);
            }
            catch (Exception ex)
            {
                var errCode = "ERR_GEN_SVR";
                return BuildErrorResponse(ex.Message, errCode);
            }
        }

        protected HttpResponseMessage PerformOperation<T>(Func<T> action)
        {
            try
            {
                var result = action();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (ServerErrorException ex)
            {
                return BuildErrorResponse(ex.Message, ex.ErrorCode);
            }
            catch (Exception ex)
            {
                var errCode = "ERR_GEN_SVR";
                return BuildErrorResponse(ex.Message, errCode);
            }
        }

        private HttpResponseMessage BuildErrorResponse(string message, string errCode)
        {
            var httpError = new HttpError(message);
            httpError["errCode"] = errCode;
            var statusCode = ErrorToStatusCodes[errCode];
            return Request.CreateErrorResponse(statusCode, httpError);
        }
    }
}