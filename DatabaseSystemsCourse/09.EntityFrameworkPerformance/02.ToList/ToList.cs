using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikEntities;
using System.Diagnostics;

namespace _02.ToList
{
    class ToList
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities db = new TelerikAcademyEntities();
            string firstResult, secondResult;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var towns = db.Employees.ToList()
                .Select(emp => emp.Address).ToList()
                .Select(town => town.Town).ToList()
                .Where(town => town.Name == "Sofia");

            sw.Stop();
            firstResult = sw.Elapsed.ToString();

            

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }

            sw.Restart();
            towns = db.Employees
                .Select(emp => emp.Address)
                .Select(town => town.Town)
                .Where(town => town.Name == "Sofia");

            foreach (var town in towns)
            {
                Console.WriteLine(town.Name);
            }

            sw.Stop();
            secondResult = sw.Elapsed.ToString();

            Console.WriteLine("Time with ToList: {0}", firstResult);
            Console.WriteLine("Time without ToList: {0}", secondResult);
        }
    }
}
