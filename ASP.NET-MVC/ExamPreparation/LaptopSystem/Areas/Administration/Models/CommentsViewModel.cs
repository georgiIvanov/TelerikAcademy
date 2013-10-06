using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.Areas.Administration.Models
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ByUser { get; set; }
        public string OnLaptop { get; set; }
    }
}