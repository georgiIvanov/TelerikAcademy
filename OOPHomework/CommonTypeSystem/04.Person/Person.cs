using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person("lala", 36);
            Person per1 = new Person("lala", null);
            Console.WriteLine(per);
            Console.WriteLine(per1);

        }
    }

    public class Person
    {
        string name;
        int? age;

        public Person(string name, int? age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            string msg = name + " ";
            if (age == null)
            {
                msg += "age not specified";
            }
            else
                msg += age;

            return msg;
        }

    }
}
