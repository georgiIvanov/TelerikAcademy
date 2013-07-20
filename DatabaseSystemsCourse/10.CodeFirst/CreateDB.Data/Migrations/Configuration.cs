namespace _01.CreateDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _01.CreateDB.Models;

    public sealed class Configuration : DbMigrationsConfiguration<_01.CreateDB.Data.UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_01.CreateDB.Data.UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.
            
            context.Courses.AddOrUpdate(
              new Course
              {
                  Name = "Databases",
                  Description = "Become master DBA",
                  Materials = "get SQL Management Studio"
              },
              new Course
              {
                  Name = "CSharp",
                  Description = "Become a ninja dev",
                  Materials = "Introduction To Programming"
              },
              new Course
              {
                  Name = "JavaScript",
                  Description = "Web frontend mastery",
                  Materials = "all the internet"
              }
            );

            context.Homeworks.AddOrUpdate(
                new Homework
                {
                    Content = "Recursion",
                    TimeSent = DateTime.Now
                },
                new Homework
                {
                    Content = "Ultimate JSApp",
                    TimeSent = DateTime.Now
                },
                new Homework
                {
                    Content = "EF CodeFirst",
                    TimeSent = DateTime.Now
                }
                );

            Random rng = new Random();
            for (int i = 0; i < 3; i++)
            {
                context.Students.AddOrUpdate(new Student
                {
                    StudentId = i,
                    Name = rng.Next(0, 100).ToString(),
                    Homeworks = context.Homeworks.Take(rng.Next(0, 4)).ToList(),
                });
            }

            context.SaveChanges();
        }
    }
}
