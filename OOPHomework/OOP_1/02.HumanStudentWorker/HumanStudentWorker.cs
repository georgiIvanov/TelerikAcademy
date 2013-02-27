using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanStudentWorker
{
    class HumanStudentWorker
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("AAA", "AAA", 4.54));
            students.Add(new Student("BBB", "BBB", 2.54));
            students.Add(new Student("ABB", "ABC", 3.54));
            students.Add(new Student("CCC", "ACC", 4.89));
            students.Add(new Student("AAA", "AAA", 6));
            students.Add(new Student("ZAR", "ZAA", 3.33));
            students.Add(new Student("WWA", "REW", 5.99));
            students.Add(new Student("AAA", "AAA", 4.54));
            students.Add(new Student("WRA", "APA", 4.66));
            students.Add(new Student("HJL", "AAA", 3.14));

            var sortedByGrade = students.OrderBy(x => x.Grade);
            foreach (var item in sortedByGrade)
            {
                Console.WriteLine("{0} {1} {2}",item.FirstName, item.LastName, item.Grade);
            }
            Console.WriteLine(); Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("FAA", "LAA", 100.23, 4));
            workers.Add(new Worker("AAA", "RRR", 120.23, 88));
            workers.Add(new Worker("MMA", "MMA", 32342132, 99));
            workers.Add(new Worker("TYY", "TYY", 3.23, 10));
            workers.Add(new Worker("FAA", "LAA", 2342, 15));
            workers.Add(new Worker("RRR", "RRR", 121, 8));
            workers.Add(new Worker("RRR", "AAA", 66.66, 8));
            workers.Add(new Worker("CCC", "QQQ", 666, 8));
            workers.Add(new Worker("AWR", "AWR", 200, 7));
            workers.Add(new Worker("ZZZ", "ZWA", 98, 7));

            var sortedByMPH = workers.OrderBy(x => x.MoneyPerHour());

            foreach (var item in sortedByMPH)
            {
                Console.WriteLine("{0} {1}\t{2}\t{3}\t{4:F2}", item.FirstName, item.LastName, item.WeekSalary, item.WorkHoursPerDay, item.MoneyPerHour());
            }
            Console.WriteLine();

            //var mergedList = workers.Join(students, 
            //                            worker => worker.FirstName, 
            //                            stud => stud.FirstName, 
            //                            (stud, worker) => new { sFirstName = stud.FirstName, sLastName = stud.LastName, wFirstName =  worker.FirstName, wLastName = worker.LastName });

            //foreach (var item in mergedList)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}",item.sFirstName, item.sLastName, item.wFirstName, item.wLastName);
            //}

            List<dynamic> mergedList = new List<dynamic>();
            foreach (var item in students)
            {
                mergedList.Add(item);
            }

            foreach (var item in workers)
            {
                mergedList.Add(item);
            }

            var sortedMerged = from item in mergedList
                               orderby item.FirstName, item.LastName
                               select item;

            foreach (var item in sortedMerged)
            {
                Console.WriteLine("{0} {1}",item.FirstName, item.LastName);
            }
        }
    }

    class Human
    {
        string firstName, lastName;

        public Human(string firstname, string lastname)
        {
            this.firstName = firstname;
            this.lastName = lastname;
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }
    }

    class Student : Human
    {
        double grade;

        public Student(string firstName, string lastName, double grade) : base(firstName, lastName)
        {
            this.grade = grade;
            
        }

        public double Grade
        {
            get { return this.grade; }
        }
    }

    class Worker : Human
    {
        double weekSalary;
        int workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }


        public double MoneyPerHour()
        {
            return weekSalary / workHoursPerDay * 5;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
        }
    }

}
