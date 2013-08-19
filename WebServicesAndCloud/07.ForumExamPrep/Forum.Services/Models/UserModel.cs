using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Services.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string AuthCode { get; set; }
    }
}