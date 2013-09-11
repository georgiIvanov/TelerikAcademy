using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext()
            : base("TodoDb")
        {

        }

        public DbSet<TodoEntry> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
