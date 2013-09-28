using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Tvvitter.Models;

namespace Tvvitter.Data
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class TvvitterContext :  IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Tag> Tags { get; set; }

    }
}