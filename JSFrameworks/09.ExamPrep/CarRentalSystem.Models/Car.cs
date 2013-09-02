using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }
        public int Engine { get; set; }

        public virtual CarState State { get; set; }
        public virtual Store Store { get; set; }

        public virtual User RentedBy { get; set; }
    }

    public class CarState
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public CarState()
        {
            this.Cars = new HashSet<Car>();
        }
    }

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AuthenticationCode { get; set; }
        public string SessionKey { get; set; }

        public virtual ICollection<Car> RentedCars { get; set; }
    }
}
