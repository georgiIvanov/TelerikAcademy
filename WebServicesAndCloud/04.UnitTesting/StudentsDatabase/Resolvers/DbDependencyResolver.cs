using SchoolDatabase.DataLayer;
using StudentsDatabase.Controllers;
using StudentsDatabase.Models;
using StudentsDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace StudentsDatabase.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext studentsDatabaseContext = new StudentsDatabaseContext();

        private static IRepository<Student> studentRepository = new DbStudentRepository(studentsDatabaseContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(studentRepository);
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