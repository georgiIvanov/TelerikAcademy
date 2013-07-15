using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

namespace _01.NorthwindEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            northwindEntities nwDB = new northwindEntities();

            var clients = from client in nwDB.Customers
                          select client.ContactName;

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }
    }
}
