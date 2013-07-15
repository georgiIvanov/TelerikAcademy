using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Library;

// Create procedure in sql server, code below
namespace _10.SupplierIncome
{
    class SupplierIncome
    {
        static void Main(string[] args)
        {
            northwindEntities db = new northwindEntities();

            string companyName = "Exotic Liquids";
            var startDate = DateTime.Parse("1980.01.21");
            var endDate = DateTime.Parse("1999.01.22");

            var income = db.uspSupplierIncome(companyName, startDate, endDate).First();

            Console.WriteLine(income);
        }
    }
}

// Create procedure in sql server
//CREATE PROCEDURE uspSupplierIncome @supplierName nvarchar(50), @startDate smalldatetime, @endDate smalldatetime
//AS
//BEGIN TRAN
//SELECT SUM(inv.ExtendedPrice) AS Income FROM Products prod
//JOIN Invoices inv
//ON inv.ProductID = prod.ProductID
//JOIN  Suppliers sup
//ON sup.SupplierID = prod.SupplierID AND sup.CompanyName = @supplierName
//WHERE inv.OrderDate > @startDate AND inv.OrderDate < @endDate
//GROUP BY sup.SupplierID
//COMMIT