using Settlements.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settlements.Data
{
    public class SettlementsContext : DbContext
    {
        public SettlementsContext()
            : base("SettlementsDb")
        {

        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}
