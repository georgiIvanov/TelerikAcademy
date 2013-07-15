using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

namespace _99.Demo
{
    class Demo
    {
        static void Main(string[] args)
        {
            northwindEntities db = new northwindEntities();

            var aa = (from orders in db.Orders
                     join emp in db.Employees
                     on orders.EmployeeID equals emp.EmployeeID
                     where emp.FirstName.Length < 20
                     select emp.FirstName).Distinct();

            foreach (var item in aa)
            {
                Console.WriteLine("{0}",item);
            }


        }
    }
}
