using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("lala", "lol", "rofl", "hladilnika", 666, 088811111, "fu@gmail.bg",
                "Hardware manufacturing", Specialty.KST, University.FreeUniversity, Faculty.Technical);

            Student b = new Student("lala", "lol", "rofl", "hladilnika", 666, 088811111, "fu@gmail.bg",
                "Hardware manufacturing", Specialty.KST, University.FreeUniversity, Faculty.Technical);

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());

            if (a == b)
            {
                Console.WriteLine("a == b");
            }

            if (a.Equals(b))
            {
                Console.WriteLine("Equals ");
            }

            if (a != b)
            {
                Console.WriteLine("a and b are not equal");
            }

            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());

            Student s = new Student("lala1", "lol", "rofl", "hladilnika", 666, 088811111, "fu@gmail.bg",
                "Hardware manufacturing", Specialty.KST, University.FreeUniversity, Faculty.Technical);
            Console.WriteLine(s.GetHashCode());

            if (a != s)
            {
                Console.WriteLine("a and c are not equal");
            }

        }
    }

    enum Specialty
    {
        KST, SoftwareArchitechure, Lalala
    }
    enum University
    {
        SU, TU, VTU, NBU, FreeUniversity
    }
    enum Faculty
    {
        Technical, Sport, Blabla, lala
    }

    class Student
    {
        string firstName, secondName, lastName;
        int SSN;
        int mobilePhone;
        string permanentAddress;
        string email;
        string course;
        Specialty spec;
        University uni;
        Faculty fac;

        public Student(string firstName, string secondName, string lastName, string permanentAddress, int SSN, int mobilePhone,
                        string email, string course, Specialty spec, University uni, Faculty fac)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.SSN = SSN;
            this.mobilePhone = mobilePhone;
            this.permanentAddress = permanentAddress;
            this.email = email;
            this.course = course;
            this.spec = spec;
            this.uni = uni;
            this.fac = fac;
        }

        public override bool Equals(object obj)
        {
            Student lala = (Student)obj;
            if (this.firstName == lala.firstName && this.secondName == lala.secondName &&
                this.lastName == lala.lastName && this.SSN == lala.SSN && 
                this.permanentAddress == lala.permanentAddress && this.mobilePhone == lala.mobilePhone)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string message = firstName + " " + secondName + " " + lastName + " " + SSN;
            return message;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + firstName.GetHashCode();
                hash = hash * 23 + secondName.GetHashCode();
                hash = hash * 23 + lastName.GetHashCode();
                hash = hash * 19 + SSN.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Student x, Student y)
        {
            return x.Equals(y);
        }

        public static bool operator != (Student x, Student y)
        {
            return !x.Equals(y);
        }
    }
}
