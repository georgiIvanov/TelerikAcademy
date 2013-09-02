using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Models;

namespace CarRentalSystem.Data
{
    public class CarRentalSystemContext : DbContext
    {
        public IDbSet<Car> Cars { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Store> Stores { get; set; }
        public IDbSet<CarState> States { get; set; }

        public CarRentalSystemContext()
            : base("CarRentalSystemDb")
        {
        }
    }
}
