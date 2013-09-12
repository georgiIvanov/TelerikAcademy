using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Counter.Data
{
    public class CounterContext : DbContext
    {
        public CounterContext()
            : base("CounterDb")
        {

        }

        public DbSet<Visitor> Visitors { get; set; }

    }

    public class Visitor
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
