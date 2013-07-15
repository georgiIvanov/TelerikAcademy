using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

namespace _10.SupplierIncome
{
    class SupplierIncome
    {
        static void Main(string[] args)
        {
            northwindEntities db = new northwindEntities();

            string companyName = "Exotic Liquids";
            var startDate = DateTime.Parse("1980.01.21");
            var endDate = DateTime.Parse("1999.01.22");

            var income = db.uspSupplierIncome(companyName, startDate, endDate).First();

            Console.WriteLine(income);
        }
    }
}
