using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tvvitter.Models
{
    public class ApplicationUser : User
    {
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}