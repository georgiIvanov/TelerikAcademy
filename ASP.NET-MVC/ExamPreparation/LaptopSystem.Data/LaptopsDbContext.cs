using LaptopSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Data
{
    public class LaptopsDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public virtual IDbSet<Laptop> Laptops { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<Comment> Comments { get; set; }
        public virtual IDbSet<Vote> Votes { get; set; }
    }
}
