using StudentsDatabase.Models;
using StudentsDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Tests.Controllers
{
    public class FakeStudentRepository : DbStudentRepository
    {
        public List<Student> students;

        public FakeStudentRepository(DbContext dbContext)
            : base(dbContext)
        {
            dbContext.Dispose();
            students = new List<Student>();
        }

        public override IQueryable<Student> All()
        {
            return students.AsQueryable();
        }

        public override Student Get(int id)
        {
            return students[id - 1];
        }

        public override Student Add(Student entity)
        {
            students.Add(entity);
            return entity;
        }

        public override IEnumerable<Student> GetStudentsWithMarkGreaterThan(string subject, double value)
        {
            var found = (from st in students
                         from m in st.Marks
                         where m.Value >= value
                         where m.Subject == subject
                         select st).ToList();

            return found;
        }

        public override Student Update(int id, Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
