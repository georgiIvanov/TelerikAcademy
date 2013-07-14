using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _01.RetrieveNorthwind
{
    class RetrieveNorthwind
    {
        static void Main(string[] args)
        {
            SqlConnection dbConn = new SqlConnection(
                "Server=.; Database=Northwind; Integrated Security = true");

            dbConn.Open();

            using (dbConn)
            {
                SqlCommand getCategoriesCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbConn);

                int categoriesCount = (int)getCategoriesCount.ExecuteScalar();

                Console.WriteLine("Number of categories: {0}", categoriesCount);
            }


        }
    }
}
