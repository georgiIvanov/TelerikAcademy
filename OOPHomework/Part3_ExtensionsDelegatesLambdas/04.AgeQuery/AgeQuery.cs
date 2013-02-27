using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AgeQuery
{
    class AgeQuery
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            
            students.Add(new Student("Shu","Shuu", 90));
            students.Add(new Student("Ku","-Ku", 20));
            students.Add(new Student("Bruce", "Wayne", 24));
            students.Add(new Student("Ala", "Bala", 25));
            students.Add(new Student("Foo", "Foo", 18));

            List<Student> youngStudents = (from stud in students
                                           where stud.age >= 18 && stud.age <= 24
                                           select stud).ToList();
            foreach (var item in youngStudents)
            {
                Console.WriteLine("{0} {1} {2}",item.firstName, item.lastName, item.age);
            }


        }
    }

    class Student
    {
        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        
        public Student(string firstName, string lastName, int age)
        {
            this.age = age;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
