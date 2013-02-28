using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHierarchy
{
    class SchoolHierarchy
    {
        static void Main(string[] args)
        {
            List<Discipline> allDisciplines = new List<Discipline>();
            allDisciplines.Add(new Discipline("Physics", 4, 4));
            allDisciplines.Add(new Discipline("Math", 3, 4));
            allDisciplines.Add(new Discipline("ForeignLanguage", 4, 8));
            allDisciplines.Add(new Discipline("Programming", 4, 8));
            allDisciplines.Add(new Discipline("Art", 4, 4));
            allDisciplines.Add(new Discipline("Geography", 4, 4));

            List<Teacher> allTeachers = new List<Teacher>();

            allTeachers.Add(new Teacher("Lala", "Tata", allDisciplines[0]));
            allTeachers[0].AddDiscipline(allDisciplines[1]);

            allTeachers.Add(new Teacher("Bla", "Bla", allDisciplines[2]));
            allTeachers[1].AddDiscipline(allDisciplines[4]);
            
            allTeachers.Add(new Teacher("Foo", "Foo"));
            allTeachers[2].AddDiscipline(allDisciplines[3]);
            allTeachers[2].AddDiscipline(allDisciplines[5]);


            List<Student> allStudents = new List<Student>();
            allStudents.Add(new Student("ttt", "mmm", 1));
            allStudents.Add(new Student("mmm", "KKK", 2));
            allStudents.Add(new Student("ppp", "yyy", 3));
            allStudents.Add(new Student("aaa", "bbb", 4));
            allStudents.Add(new Student("www", "eee", 5));
            allStudents.Add(new Student("rrr", "ccc", 6));
            allStudents.Add(new Student("sss", "qqq", 7));
            allStudents.Add(new Student("zzz", "xxx", 8));


            List<Class> classes = new List<Class>();
            classes.Add(new Class("12a", 
                                new Teacher[] { allTeachers[0], allTeachers[1] }, 
                                new Student[] { allStudents[0], allStudents[1], allStudents[2], allStudents[3] }));
            classes.Add(new Class("12b",
                                new Teacher[] { allTeachers[0], allTeachers[1] },
                                new Student[] { allStudents[4], allStudents[5], allStudents[6], allStudents[7] }));

            School school = new School();

            school.AddClass(classes[0]);
            school.AddClass(classes[1]);

            Class getClass = school.GetClassByID("12a");
            Console.WriteLine("Original\nclass: {0} \nstudents: {1}",getClass.GetUTID, getClass.GetNumberOfStudents);
            getClass.AddStudent(allStudents[5]);
            Console.WriteLine("\nAdded a student to a class -\nclass: {0} \nstudents: {1}", getClass.GetUTID, getClass.GetNumberOfStudents);
            getClass.RemoveStudent(allStudents[0]);
            Console.WriteLine("\nRemoved a student -\nclass: {0} \nstudents: {1}", getClass.GetUTID, getClass.GetNumberOfStudents);
        }
    }

    class School
    {
        Dictionary<string, Class> classes;

        public School()
        {
            classes = new Dictionary<string, Class>();
        }

        public void AddClass(Class newClass)
        {
            if (!classes.ContainsKey(newClass.GetUTID))
                classes.Add(newClass.GetUTID, newClass);
            else
            {
                throw new ArgumentException("Class already exists");
            }
        }

        public List<Class> ReturnAllClasses()
        {
            List<Class> allClasses = (from cl in classes
                                      select cl.Value).ToList();
            return allClasses;
        }

        public Class GetClassByID(string key)
        {
            return classes[key];
        }

        public int StudentsInClass(string key)
        {
            return classes[key].GetNumberOfStudents;
        }
    }

    class Person
    {
        string firstName, lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName 
        {
            get { return firstName; }
        }
        public string LastName
        {
            get { return this.lastName; }
        }
    }

    class Student : Person
    {
        int ucn; //unique class number

        public Student(string firstName, string lastName, int ucn)
            : base(firstName, lastName)
        {
            this.ucn = ucn;
        }

        public int GetUCN
        {
            get { return this.ucn; }
        }
    }

    class Teacher : Person
    {
        List<Discipline> disciplines;

        public Teacher(string firstName, string secondName) 
            : base(firstName, secondName)
        {
            disciplines = new List<Discipline>();
        }

        public Teacher(string firstName, string secondName, Discipline disc) 
            : base(firstName, secondName)
        {
            disciplines = new List<Discipline>();
            disciplines.Add(disc);
        }

        public void AddDiscipline(Discipline disc)
        {
            disciplines.Add(disc);
        }
        public void RemoveDiscipline(Discipline disc)
        {
            disciplines.Remove(disc);
        }
        public List<Discipline> ReturnDisciplines()
        {
            List<Discipline> alldisc = (from disc in disciplines
                                        select disc).ToList();
            return alldisc;
        }
    }

    class Discipline
    {
        string name;
        int lecturesCount, exercisesCount;

        public Discipline(string name, int lecturesCount, int exercisesCount)
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
        }
    }

    class Class
    {
        string utid; //unique text identifier
        List<Teacher> setOfTeachers;
        List<Student> setOfStudents;

        public Class(string uniqueClassID)
        {
            this.utid = uniqueClassID;
            setOfTeachers = new List<Teacher>();
            setOfStudents = new List<Student>();
        }

        public Class(string uniqueClassID, Teacher[] teachers, Student[] students)
        {
            this.utid = uniqueClassID;
            setOfTeachers = new List<Teacher>();
            setOfStudents = new List<Student>();
            foreach (var item in teachers)
            {
                this.AddTeacher(item);
            }
            foreach (var item in students)
            {
                this.AddStudent(item);
            }
        }

        public string GetUTID
        {
            get { return this.utid; }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (!setOfTeachers.Contains(teacher))
                setOfTeachers.Add(teacher);
            else
            {
                throw new ArgumentException("Teacher is already here");
            }
        }
        public void RemoveTeacher(Teacher teacher)
        {
            setOfTeachers.Remove(teacher);
        }
        public void AddStudent(Student stud)
        {
            if (!setOfStudents.Contains(stud))
                setOfStudents.Add(stud);
            else
            {
                throw new ArgumentException("Student is already here");
            }
        }
        public void RemoveStudent(Student stud)
        {
            setOfStudents.Remove(stud);
        }

        public int GetNumberOfStudents
        {
            get { return setOfStudents.Count; }
        }

        public int GetNumberOfTeachers
        {
            get { return setOfTeachers.Count; }
        }
    }
}
