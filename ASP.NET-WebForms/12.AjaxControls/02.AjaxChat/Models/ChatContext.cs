using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02.AjaxChat.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext()
            : base("AjaxChatDb")
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}