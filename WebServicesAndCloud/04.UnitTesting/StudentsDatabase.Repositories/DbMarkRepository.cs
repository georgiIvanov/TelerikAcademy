using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Repositories
{
    class DbMarkRepository : IRepository<Mark>
    {
        DbContext dbContext;
        DbSet<Mark> entitySet;

        public DbMarkRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Mark>();
        }

        public Mark Add(Mark entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public Mark Update(int id, Mark entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mark Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Mark> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Mark> Find(System.Linq.Expressions.Expression<Func<Mark, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
