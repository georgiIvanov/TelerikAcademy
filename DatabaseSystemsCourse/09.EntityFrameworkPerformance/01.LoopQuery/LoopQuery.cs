using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikEntities;
using System.Diagnostics;

namespace _01.LoopQuery
{
    class LoopQuery
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();
            string firstResult, secondResult;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            PrintWithoutInclude(db);

            sw.Stop();
            firstResult = sw.Elapsed.ToString();

            sw.Restart();
            PrintWithInclude(db);
            sw.Stop();
            secondResult = sw.Elapsed.ToString();

            Console.WriteLine("Time without include: {0}", firstResult);
            Console.WriteLine("Time with include: {0}", secondResult);

        }

        private static void PrintWithInclude(TelerikAcademyEntities db)
        {
            foreach (var emp in db.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("DepartmentID: {0}, {1} {2}\tFrom {3}",
                    emp.Department.DepartmentID,
                    emp.FirstName,
                    emp.LastName,
                    emp.Address.Town.Name);
            }
        }

        private static void PrintWithoutInclude(TelerikAcademyEntities db)
        {
            foreach (var emp in db.Employees)
            {
                Console.WriteLine("DepartmentID: {0}, {1} {2}\tFrom {3}",
                    emp.Department.DepartmentID,
                    emp.FirstName,
                    emp.LastName,
                    emp.Address.Town.Name);
            }
        }
    }
}
