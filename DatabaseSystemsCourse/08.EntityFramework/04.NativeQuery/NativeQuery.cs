using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

namespace _04.NativeQuery
{
    class NativeQuery
    {
        static void Main(string[] args)
        {
            string query = "SELECT cust.ContactName FROM Customers cust " +
            "INNER JOIN Orders ord " +
            "ON ord.CustomerID = cust.CustomerID " +
            "WHERE YEAR(ord.OrderDate) = {0} AND ord.ShipCountry = {1} ";

            object[] parameters = { 1997, "Canada" };

            using (var context = new northwindEntities())
            {
                var ContactNames = context.Database.SqlQuery<string>(query,parameters).ToList();

                foreach (var name in ContactNames)
                {
                    Console.WriteLine("{0}", name);
                }
            }

        }
    }
}
