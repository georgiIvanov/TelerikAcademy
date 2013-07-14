using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NameAndDescription
{
    class NameAndDescription
    {
        static void Main(string[] args)
        {
            SqlConnection dbConn = new SqlConnection(
                "Server=.; Database=Northwind; Integrated Security = true");

            dbConn.Open();

            using (dbConn)
            {
                SqlCommand getCategories = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbConn);

                SqlDataReader reader = getCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string line = string.Format("{0,15} - {1}",
                            (string)reader["CategoryName"],
                            (string)reader["Description"]);
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
