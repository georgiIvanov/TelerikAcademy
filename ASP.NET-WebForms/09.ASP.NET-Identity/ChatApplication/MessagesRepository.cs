using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public class MessagesRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Message> Select()
        {
            var found = db.Messages.Include("Author").ToList();
            return found;
        }

        public void Insert(string Text)
        {
            
            db.Messages.Add(new Message()
            {
                
            });
        }

        public void Edit(int Id, string Text, string Author)
        {
            var foundMessage = db.Messages.Single(x => x.Id == Id);
            foundMessage.Text = Text;
            db.SaveChanges();
        }

        public void Delete(int Id, string Text, string Author)
        {
            var foundMessage = db.Messages.Single(x => x.Id == Id);
            db.Messages.Remove(foundMessage);
            db.SaveChanges();
        }
    }
}