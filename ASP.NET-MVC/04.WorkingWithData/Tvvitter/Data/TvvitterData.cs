using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tvvitter.Models;

namespace Tvvitter.Data
{
    public class TvvitterData : ITvvitterData
    {
        private readonly TvvitterContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public TvvitterData()
            :this (new TvvitterContext())
        {

        }

        public TvvitterData(TvvitterContext context)
        {
            this.context = context;
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
            set { }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
            set { }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
            set { }
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
    }
}