using LaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopSystem.Areas.Administration.Models
{
    public class LaptopCreateViewModel
    {
        public Laptop Laptop { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
    }
}