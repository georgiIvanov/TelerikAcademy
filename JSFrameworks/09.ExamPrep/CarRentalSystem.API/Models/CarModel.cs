using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Web;

namespace CarRentalSystem.API.Models
{
    [DataContract]
    public class CarModel
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "make")]
        public string Make { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "engine")]
        public int Engine { get; set; }

        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        public static Expression<Func<Car, CarModel>> FromCar
        {
            get
            {
                return car =>
                new CarModel()
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    Engine = car.Engine,
                    Power = car.Power,
                    Year = car.Year
                };
            }
        }
    }
}