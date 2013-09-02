using System;
using CarRentalSystem.API.Headears;
using CarRentalSystem.API.Models;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ValueProviders;
using System.Web.Http;

namespace CarRentalSystem.API.Controllers
{
    public class CarsController : BaseApiController
    {
        public CarsController()
            : this(new CarRentalSystemContextFactory())
        {
        }

        public CarsController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        {
        }

        public IEnumerable<CarModel> GetAll()
        {
            var response =
            this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();

                var freeCarModels = (context.Set<Car>()
                              .Where(car => car.State.Value == "free")
                              .Select(CarModel.FromCar)).ToList();
                return freeCarModels;
            });
            return response;
        }

        [ActionName("rent")]
        public HttpResponseMessage PutRentCar(int carId,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(carId);
                if (car == null)
                {
                    throw new InvalidOperationException("The car does not exist");
                }
                var freeState = context.Set<CarState>().FirstOrDefault(st => st.Value == "free");
                var rentedState = context.Set<CarState>().FirstOrDefault(st => st.Value == "rented");
                if (car.State != freeState)
                {
                    throw new InvalidOperationException("The car is already rented");
                }
                car.State = rentedState;
                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        [ActionName("return")]
        public HttpResponseMessage PutReturnCar(int carId,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(carId);
                if (car == null)
                {
                    throw new InvalidOperationException("The car does not exist");
                }
                var freeState = context.Set<CarState>().FirstOrDefault(st => st.Value == "free");
                var rentedState = context.Set<CarState>().FirstOrDefault(st => st.Value == "rented");
                if (car.State != rentedState || car.RentedBy != user)
                {
                    throw new InvalidOperationException("The car is not rented by you");
                }
                car.State = freeState;
                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }
    }
}