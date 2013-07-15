using EntityFramework.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CreateDAO
{
    class CreateDAO
    {
        static void Main(string[] args)
        {
           
            //NorthwindDOA.InsertCustomer(50,"Selo Ltd", "This is deleted", "BG", "525");

            NorthwindDOA.UpdateCustomerName(100, "Vanyo");

            NorthwindDOA.DeleteCustomer(50);

            
            Console.WriteLine(NorthwindDOA.PrintFirstNCustomers(5));
        }
    }


}
