using CodeJewels.DataLayer;
using CodeJewels.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace CodeJewels.Service.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static CodeJewelsContext dbContext = new CodeJewelsContext();



        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CategoryJewelsController))
            {
                return new CategoryJewelsController(dbContext);
            }
            else if (serviceType == typeof(CodeJewelsController))
            {
                return new CodeJewelsController(dbContext);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            
        }
    }
}