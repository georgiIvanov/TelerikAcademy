using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Data
{
    public class LaptopData : IUoWLaptopData
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public DbContext Context
        {
            get { return this.context; }
        }

        public LaptopData()
            : this(new LaptopsDbContext())
        {
        }

        public LaptopData(LaptopsDbContext context)
        {
            this.context = context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public IRepository<Laptop> Laptops
        {
            get
            {
                return this.GetRepository<Laptop>();
            }
            set
            { }
        }

        public IRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
            set
            { }
        }

        public IRepository<Models.ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
            set
            { }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
            set
            { }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
            set
            { }
        }
    }
}
