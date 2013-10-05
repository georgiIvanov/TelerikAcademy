using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class LaptopDetailsViewModel
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public double Inches { get; set; }
        public double Harddisk { get; set; }
        public double Ram { get; set; }
        public double Weight { get; set; }
        public string AdditionalParts { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}