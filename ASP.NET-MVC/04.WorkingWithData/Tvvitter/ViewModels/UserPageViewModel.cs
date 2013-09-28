using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tvvitter.Models;

namespace Tvvitter.ViewModels
{
    public class UserPageViewModel
    {
        public string Username { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
        public Tweet Tweet { get; set; }
    }
}