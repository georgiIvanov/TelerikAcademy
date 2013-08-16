using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected DbContext dbContext;
        protected DbSet<T> entitySet;

        public AbstractRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            this.entitySet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public abstract T Update(int id, T entity);

        public virtual void Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }

        public virtual T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public virtual IQueryable<T> All()
        {
            return this.entitySet;
        }

        public virtual IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
