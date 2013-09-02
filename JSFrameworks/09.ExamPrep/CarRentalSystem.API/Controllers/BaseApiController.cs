using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalSystem.API.Controllers
{
    public class BaseApiController : ApiController
    {
        private IDbContextFactory<DbContext> contextFactory;

        protected IDbContextFactory<DbContext> ContextFactory
        {
            get
            {
                return this.contextFactory;
            }
        }

        public BaseApiController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation, HttpStatusCode errStatusCode = HttpStatusCode.BadRequest, string errMessage = null)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse =
                    this.Request
                        .CreateErrorResponse(HttpStatusCode.BadRequest,
                            (errMessage != null) ? errMessage : ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected User LoginUser(string sessionKey, DbContext context)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("User is not authenticated");
            }
            return user;
        }
    }
}
