using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentSort
{
    class StudentSort
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Aladdin", "Farenheit"));
            students.Add(new Student("Sam", "Am"));
            students.Add(new Student("Erlang", "Pascal"));
            students.Add(new Student("Harrhr", "Eacutl"));
            

            var foundStudents = (from stud in students
                                where string.Compare(stud.firstName, stud.lastName) < 0
                                select stud).ToList();

            foreach (var item in foundStudents)
            {
                Console.WriteLine("{0} {1}", item.firstName, item.lastName);
            }
        }
    }

    class Student
    {
        public string firstName { get; set; }
        public string lastName  { get; set; }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
