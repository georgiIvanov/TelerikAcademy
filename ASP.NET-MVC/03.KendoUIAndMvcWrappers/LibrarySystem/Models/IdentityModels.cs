using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LibrarySystem.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class LibraryDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public LibraryDbContext()
        {
            base.Database.Connection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\LibrarySystem-Homework.mdf;Initial Catalog=LibrarySystem-Homework;Integrated Security=True";
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    
}