using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class LaptopIndexViewModel
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}