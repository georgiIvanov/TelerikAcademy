using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace Forum.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponce = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

                throw new HttpResponseException(errResponce);
            }
        }
    }
}