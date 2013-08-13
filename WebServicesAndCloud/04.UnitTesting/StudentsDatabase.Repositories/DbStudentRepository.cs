using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StudentsDatabase.Repositories
{
    public class DbStudentRepository : AbstractRepository<Student>
    {
        public DbStudentRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<Student> GetStudentsWithMarkGreaterThan(string subject, double value)
        {
            var found = (from st in base.entitySet
                        from m in st.Marks
                        where m.Value >= value
                        where m.Subject == subject
                        select st).ToList();

            return found;
        }

        public override Student Update(int id, Student entity)
        {
            var found = base.entitySet.Find(id);
            if (found != null)
            {
                found.FirstName = entity.FirstName;
                found.LastName = entity.LastName;
                found.Age = entity.Age;
                found.Grade = entity.Grade;
                found.Marks = entity.Marks;
                found.SchoolId = entity.SchoolId;

                base.dbContext.SaveChanges();
            }

            return found;
        }
    }
    //public class DbStudentRepository : IRepository<Student>
    //{
    //    DbContext dbContext;
    //    DbSet<Student> entitySet;

    //    public DbStudentRepository(DbContext dbContext)
    //    {
    //        if (dbContext == null)
    //        {
    //            throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
    //        }

    //        this.dbContext = dbContext;
    //        this.entitySet = this.dbContext.Set<Student>();
    //    }

    //    public IQueryable<Student> Find(Expression<Func<Student, int, bool>> predicate)
    //    {
    //        return this.entitySet.Where(predicate);
    //    }

    //    public Student Add(Student entity)
    //    {
    //        this.entitySet.Add(entity);
    //        this.dbContext.SaveChanges();
    //        return entity;
    //    }

    //    public Student Update(int id, Student entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        var entity = this.entitySet.Find(id);
    //        if (entity != null)
    //        {
    //            this.entitySet.Remove(entity);
    //            this.dbContext.SaveChanges();
    //        }
    //    }

    //    public Student Get(int id)
    //    {
    //        return this.entitySet.Find(id);
    //    }

    //    public IQueryable<Student> All()
    //    {
    //        return this.entitySet;
    //    }
    //}
}
