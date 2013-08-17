using StudentsDatabase.Controllers;
using StudentsDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace StudentsDatabase.IntegrationalTests
{
    class TestPlacesDependencyResolver<T> : IDependencyResolver
    {
        private DbStudentRepository studentsRepository;

        public DbStudentRepository StudentsRepository
        {
            get
            {
                return this.studentsRepository;
            }
            set
            {
                this.studentsRepository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.StudentsRepository);
            }
            //else if (serviceType == typeof(CategoriesController))
            //{
            //}
            return null;
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
