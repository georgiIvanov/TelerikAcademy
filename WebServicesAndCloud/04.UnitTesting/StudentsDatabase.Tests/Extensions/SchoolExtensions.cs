using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Tests
{
    public static class SchoolExtensions
    {
        public static School AddName(this School sc, string name)
        {
            sc.Name = name;
            return sc;
        }

        public static School AddLocation(this School sc, string location)
        {
            sc.Location = location;
            return sc;
        }

        public static School AddStudent(this School sc, Student stud)
        {
            sc.Students.Add(stud);
            return sc;
        }
    }
}
