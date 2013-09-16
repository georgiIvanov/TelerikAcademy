using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.AjaxChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }
}