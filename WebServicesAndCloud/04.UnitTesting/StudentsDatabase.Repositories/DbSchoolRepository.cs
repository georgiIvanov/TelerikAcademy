using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Repositories
{
    public class DbSchoolRepository : AbstractRepository<School>
    {
        public DbSchoolRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public ICollection<Student> GetStudentsInSchool(School sc)
        {
            var found = (from st in base.dbContext.Set<Student>()
                        where sc.SchoolId == st.SchoolId
                        select st).ToList();

            found = GetEntities(found).ToList();

            return found;
        }

        

        public override School Update(int id, School entity)
        {
            var found = base.entitySet.Find(id);
            if (found != null)
            {
                found.Name = entity.Name;
                found.SchoolId = entity.SchoolId;
                found.Students = entity.Students;

                base.dbContext.SaveChanges();
            }

            return found;
        }

        private static Student CreateStudentToReturn(Student found)
        {
            var student = new Student()
            {
                Id = found.Id,
                FirstName = found.FirstName,
                LastName = found.LastName,
                Age = found.Age,
                Grade = found.Grade,
                Marks = found.Marks,
                SchoolId = found.SchoolId
            };
            return student;
        }

        private static IEnumerable<Student> GetEntities(List<Student> students)
        {
            foreach (var stud in students)
            {
                yield return CreateStudentToReturn(stud);
            }
        }
    }
}
