using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<LaptopIndexViewModel> Laptops { get; set; }
    }
}