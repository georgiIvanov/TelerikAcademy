using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.WebCalculator.Models
{
    public class CalculatorConfigurationModel
    {
        public double Quantity { get; set; }
        public List<string> Types { get; set; }
        public List<string> Kilo { get; set; }
        public bool KiloIs1024 { get; set; }

    }
}