using _02.WebCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.Types = new List<string>()
            {
                "bit - b",
                "Byte - B",
                "Kilobit - Kb",
                "Kilobyte - KB",
                "Megabit - Mb",
                "Megabyte - MB",
                "Gigabit - Gb",
                "Gigabyte - GB",
                "Terabit - Tb",
                "Terabyte - TB",
                "Petabit - Pb",
                "Petabyte - PB",
                "Exabit - Eb",
                "Exabyte - EB",
                "Zettabit - Zb",
                "Zettabyte - ZB",
                "Yottabit - Yb",
                "Yottabyte - YB"
            };

            this.TypesItems = new List<SelectListItem>();
            foreach (var item in this.Types)
            {
                this.TypesItems.Add(new SelectListItem() { Text = item, Value = item });
            }
            this.Kilo = new List<SelectListItem>(){
                new SelectListItem(){ Text="1024", Value="1024"},
                new SelectListItem(){ Text="1000", Value="1000"}
            };
        }

        public List<string> Types { get; set; }
        public List<SelectListItem> TypesItems { get; private set; }
        public List<SelectListItem> Kilo { get; private set; }


        [HttpGet]
        public ActionResult Index()
        {


            this.ViewBag.Types = this.TypesItems;

            this.ViewBag.Kilo = this.Kilo;


            return View();
        }

        [HttpPost]
        public ActionResult Index(string Quantity, string Types, string Kilo)
        {
            ViewBag.Quantity = Quantity;

            var type = this.TypesItems.Single(x => x.Value == Types);
            type.Selected = true;
            this.ViewBag.Types = this.TypesItems;

            var kilo = this.Kilo.Single(x => x.Value == Kilo);
            kilo.Selected = true;
            this.ViewBag.Kilo = this.Kilo;

            List<DataSize> results = new List<DataSize>(this.TypesItems.Count);

            InitializeNames(results);

            var indexOfItem = this.Types.IndexOf(Types);
            bool BaseIs1024 = Kilo == "1024" ? true : false;
            bool IsBit = Types.IndexOf("bit") >= 0 ? true : false;
            double quantity = Convert.ToDouble(Quantity);
            double tempQuantity = quantity;
            // calculating smaller sizes

            results[indexOfItem].Size = quantity;


            for (int i = indexOfItem;;)
            {
                i -= 2;

                if (i < 0)
                {
                    break;
                }

                if (BaseIs1024)
                {
                    tempQuantity *= 1024;
                }
                else
                {
                    tempQuantity *= 1000;
                }
                results[i].Size = tempQuantity;

                if (IsBit)
                {
                    results[i + 1].Size = results[i].Size / 8;
                }
                else
                {
                    results[i + 1].Size = results[i + 2].Size * 8;
                }
            }

            if (results[0].Size == 0)
            {
                results[0].Size = results[1].Size * 8;
            }

            tempQuantity = quantity;
            for (int i = indexOfItem; ; )
            {
                i += 2;

                if (i >= results.Count)
                {
                    break;
                }

                if (BaseIs1024)
                {
                    tempQuantity /= 1024;
                }
                else
                {
                    tempQuantity /= 1000;
                }
                results[i].Size = tempQuantity;

                if (IsBit)
                {
                    results[i - 1].Size = results[i - 2].Size / 8;
                }
                else
                {
                    results[i - 1].Size = results[i].Size * 8;
                }
            }

            if (results[results.Count - 1].Size == 0)
            {
                results[results.Count - 1].Size = results[results.Count - 2].Size / 8;
            }

            this.ViewBag.Results = results;

            return View();
        }

        private void InitializeNames(List<DataSize> results)
        {
            for (int i = 0; i < this.TypesItems.Count; i++)
            {
                results.Add(new DataSize()
                {
                    Name = this.TypesItems[i].Text
                });
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}