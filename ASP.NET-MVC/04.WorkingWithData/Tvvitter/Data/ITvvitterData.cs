using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tvvitter.Models;

namespace Tvvitter.Data
{
    public interface ITvvitterData : IDisposable
    {
        IRepository<Tweet> Tweets { get; set; }
        IRepository<Tag> Tags { get; set; }
        IRepository<ApplicationUser> Users { get; set; }
        int SaveChanges();
    }
}