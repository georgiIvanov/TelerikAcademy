using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace _02.CreateDAO
{
    public static class NorthwindDOA
    {
        static northwindEntities db = new northwindEntities();

        public static bool InsertCustomer(int customerId, string companyName, string contactName, string country, string phone)
        {
            Customer newCustomer = new Customer()
            {
                CustomerID = Convert.ToString(customerId),
                CompanyName = companyName,
                ContactName = contactName,
                Country = country,
                Phone = phone
            };

            db.Customers.Add(newCustomer);
            if (db.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public static bool UpdateCustomerName(int customerId, string newName)
        {
            string strId = Convert.ToString(customerId);

            var found = (from customer in db.Customers
                        where customer.CustomerID == strId
                        select customer).First();

            found.ContactName = newName;

            if (db.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }

        public static bool DeleteCustomer(int customerId)
        {
            string strId = Convert.ToString(customerId);
            bool deleted = false;
            try
            {
                var found = (from customer in db.Customers
                             where customer.CustomerID == strId
                             select customer).First();

                db.Customers.Remove(found);

                if (db.SaveChanges() == 1)
                {
                    deleted = true;
                }

                return deleted;
            
            }
            catch (InvalidOperationException)
            {
                return deleted;
            }
        }

        public static string PrintFirstNCustomers(int n)
        {
            StringBuilder result = new StringBuilder();
            foreach (var customer in 
                (from c in db.Customers 
                select c).Take(n) )
            {
                result.AppendLine(customer.ContactName);
            }

            return result.ToString();
        }
    }
}
