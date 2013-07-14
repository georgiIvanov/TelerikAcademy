using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CategoriesAndProducts
{
    class CategoriesAndProducts
    {
        static void Main(string[] args)
        {
            SqlConnection dbConn = new SqlConnection(
                "Server=.; Database=Northwind; Integrated Security = true");

            dbConn.Open();

            using (dbConn)
            {
                SqlCommand getCategories = new SqlCommand(
                    "SELECT cat.CategoryName, prod.ProductName FROM Categories cat " +
                    "JOIN Products prod " +
                    "ON cat.CategoryID = prod.CategoryID " +
                    "GROUP BY CategoryName, prod.ProductName", dbConn);

                SqlDataReader reader = getCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string line = string.Format("{0,15} - {1}",
                            (string)reader["CategoryName"],
                            (string)reader["ProductName"]);
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
