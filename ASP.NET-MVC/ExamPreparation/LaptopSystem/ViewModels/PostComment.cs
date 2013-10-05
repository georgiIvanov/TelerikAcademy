using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class PostComment
    {
        [Required]
        public int LaptopId { get; set; }
        [StringLength(300, MinimumLength = 2)]
        public string Content { get; set; }
    }
}