using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

namespace _03.FindOrders
{
    class FindOrders
    {
        static void Main(string[] args)
        {
            northwindEntities db = new northwindEntities();

            var found = GetCustomers(db);

            foreach (var row in found)
            {
                Console.WriteLine(row);
            }
        }

        private static IEnumerable<string> GetCustomers(northwindEntities db)
        {
            var customers = (from customer in db.Customers
                             join ord in db.Orders
                             on customer.CustomerID equals ord.CustomerID
                             where ord.OrderDate.Value.Year == 1997 &&
                             ord.ShipCountry == "Canada"
                             select new
                             {
                                 CustomerID = customer.CustomerID,
                                 ContactName = customer.ContactName,
                                 OrderID = ord.OrderID,
                                 OrderDate = ord.OrderDate
                             }
                            ).Distinct();

            foreach (var item in customers)
            {
                yield return string.Format("{0} {1} - order ID:{2}, order Date: {3}",
                    item.CustomerID, item.ContactName, item.OrderID, item.OrderDate.Value.ToShortDateString());
            }
        }
    }
}
