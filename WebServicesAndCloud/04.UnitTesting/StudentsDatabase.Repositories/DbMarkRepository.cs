using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Repositories
{
    public class DbMarkRepository : AbstractRepository<Mark>
    {
        public DbMarkRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public override Mark Update(int id, Mark entity)
        {
            var found = base.entitySet.Find(id);
            if (found != null)
            {
                found.StudentId = entity.StudentId;
                found.Subject = entity.Subject;
                found.Value = entity.Value;

                base.dbContext.SaveChanges();
            }

            return found;
        }
    }
}
