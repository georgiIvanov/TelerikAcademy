using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Data
{
    public interface IUoWLaptopData : IDisposable
    {
        IRepository<Laptop> Laptops { get; set; }
        IRepository<Manufacturer> Manufacturers { get; set; }
        IRepository<ApplicationUser> Users { get; set; }
        IRepository<Comment> Comments { get; set; }
        IRepository<Vote> Votes { get; set; }
        int SaveChanges();
    }
}
