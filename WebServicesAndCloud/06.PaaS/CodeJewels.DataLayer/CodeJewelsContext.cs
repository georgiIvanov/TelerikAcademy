using CodeJewels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJewels.DataLayer.Migrations;

namespace CodeJewels.DataLayer
{
    public class CodeJewelsContext : DbContext
    {
        public CodeJewelsContext()
            : base("CodeJewels")
        {


            
        }

        public DbSet<CodeJewel> CodeJewels { get; set; }
        public DbSet<JewelCategory> JewelCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
