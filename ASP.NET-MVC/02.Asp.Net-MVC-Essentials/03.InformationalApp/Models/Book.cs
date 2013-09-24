using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03.InformationalApp.Models
{
    public class Book
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        
        [Range(0, 10, ErrorMessage= "Rating must be between 0 and 10")]
        public double Rating { get; set; }
    }
}