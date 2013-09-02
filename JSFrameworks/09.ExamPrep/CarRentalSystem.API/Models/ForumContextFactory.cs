using System.Data.Entity.Infrastructure;
using CarRentalSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CarRentalSystem.API.Models
{
    public class CarRentalSystemContextFactory: IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new CarRentalSystemContext();
        }
    }
}