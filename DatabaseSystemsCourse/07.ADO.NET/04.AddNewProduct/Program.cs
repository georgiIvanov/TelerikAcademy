using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddNewProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbConn = new SqlConnection(
                "Server=.; Database=Northwind; Integrated Security = true");

            string addedProductName = "4ai";
            decimal pricePerUnit = 100.34m;

            dbConn.Open();
            using (dbConn)
            {
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@addedProduct";
                paramName.Value = addedProductName;

                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@pricePerUnit";
                paramPrice.Value = pricePerUnit;

                SqlCommand getCategories = new SqlCommand(
                    "INSERT INTO Products (ProductName, UnitPrice) " +
                    "VALUES (@addedProduct, @pricePerUnit)", dbConn);

                getCategories.Parameters.Add(paramName);
                getCategories.Parameters.Add(paramPrice);

                int rows = getCategories.ExecuteNonQuery();
                if (rows == 1)
                {
                    Console.WriteLine("Product successfully added.");
                }
                else
                {
                    Console.WriteLine("Sum ting wong");
                }
            }
        }
    }
}
