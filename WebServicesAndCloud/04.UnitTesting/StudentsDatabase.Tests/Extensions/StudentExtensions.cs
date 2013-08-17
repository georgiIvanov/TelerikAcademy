using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Tests
{
    public static class StudentExtensions
    {

        public static School AddSchoolToDatabase(this School school, DbContext dbContext, string name = "TVU", string location = "gorata")
        {
            school = dbContext.Set<School>().Add(
                new School()
                .AddName(name)
                .AddLocation(location));

            return school;
        }

        public static Student AddFirstName(this Student student, string firstName)
        {
            student.FirstName = firstName;
            return student;
        }

        public static Student AddLastName(this Student student, string lastName)
        {
            student.LastName = lastName;
            return student;
        }

        public static Student AddSchoolId(this Student student, int id)
        {
            student.SchoolId = id;
            return student;
        }

        public static Student AddAge(this Student student, int age)
        {
            student.Age = age;
            return student;
        }

        public static Student AddGrade(this Student student, int grade)
        {
            student.Grade = grade;
            return student;
        }

        public static Student AddId(this Student student, int id)
        {
            student.Id = id;
            return student;
        }

        public static Student AddMarks(this Student student, string subject, double value, int count, int studentId = 0)
        {
            var marks = new HashSet<Mark>(Enumerable.Repeat<Mark>(new Mark()
            {
                Subject = subject,
                Value = value,
                StudentId = 0
            }, count));

            student.Marks = marks;

            return student;
        }

        
    }
}
