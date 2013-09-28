using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tvvitter.ViewModels
{
    public class TweetViewModel
    {
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Username { get; set; }
        public Guid Id { get; set; }
    }
}