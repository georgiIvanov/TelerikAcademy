using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsDatabase.Helpers
{
    public static class Serializer
    {
        public static Student CreateStudentToReturn(Student found)
        {
            var student = new Student()
            {
                Id = found.Id,
                FirstName = found.FirstName,
                LastName = found.LastName,
                Age = found.Age,
                Grade = found.Grade,
                Marks = found.Marks,
                SchoolId = found.SchoolId
            };
            return student;
        }

        public static IEnumerable<Student> GetEntities(IEnumerable<Student> students)
        {
            foreach (var stud in students)
            {
                yield return CreateStudentToReturn(stud);
            }
        }
    }
}