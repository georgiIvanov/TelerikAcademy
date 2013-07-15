using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;
using System.Threading;
using System.Globalization;

namespace _05.FindSales
{
    class FindSales
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            northwindEntities db = new northwindEntities();

            var found = GetSales(db, "SP", DateTime.Parse("1995-05-10"), DateTime.Parse("1996-09-10"));

            foreach (var row in found)
            {
                Console.WriteLine(row);
            }
        }

        private static IEnumerable<string> GetSales(northwindEntities db, 
            string Region, DateTime startDate, DateTime endDate)
        {
            var sales = (from invoice in db.Invoices
                             where invoice.Region == Region && 
                             invoice.OrderDate > startDate && 
                             invoice.OrderDate < endDate
                             select new
                             {
                                 OrderID = invoice.OrderID,
                                 OrderDate = invoice.OrderDate,
                                 ProductName = invoice.ProductName,
                                 ExtendedPrice = invoice.ExtendedPrice
                             }
                            );

            foreach (var item in sales)
            {
                yield return string.Format("ID:{0}    OrderDate: {1}\nProduct Name:{2}, Price: {3}\n",
                    item.OrderID, item.OrderDate, item.ProductName, item.ExtendedPrice);
            }
        }
    }
}