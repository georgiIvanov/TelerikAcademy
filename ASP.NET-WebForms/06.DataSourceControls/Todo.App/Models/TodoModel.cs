using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.App.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime LastModified { get; set; }
        public string Category { get; set; }
    }
}