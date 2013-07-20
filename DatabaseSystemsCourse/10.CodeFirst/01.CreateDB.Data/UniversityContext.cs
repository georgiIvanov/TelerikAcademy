using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.CreateDB.Models;

namespace _01.CreateDB.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext()
            : base("UniversityDb")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
