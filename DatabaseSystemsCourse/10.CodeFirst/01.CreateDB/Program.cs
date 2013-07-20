using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.CreateDB.Data;
using _01.CreateDB.Models;
using System.Data.Entity;
using _01.CreateDB.Data.Migrations;

namespace _01.CreateDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<UniversityContext, Configuration>());

            using (var db = new UniversityContext())
            {
                //Data is seeded automatically

                // Add a student
                //var student = new Student()
                //{
                //    Name = "Ivan",
                //    Number = 1
                //};

                //db.Students.Add(student);
                //db.SaveChanges();

                foreach (var item in db.Courses)
                {
                    Console.WriteLine("Name: {0}, \nDescription: {1}, \nMaterials: {2}\n\n", 
                        item.Name, item.Description, item.Materials);
                }

                foreach (var item in db.Students)
                {
                    Console.WriteLine("ID: {0}, Name: {1}",item.StudentId, item.Name);
                    
                }
            }
        }
    }
}
