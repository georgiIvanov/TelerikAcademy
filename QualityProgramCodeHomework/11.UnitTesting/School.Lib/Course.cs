using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        List<Student> students;
        string courseName;

        public Course(string name)
        {
            this.students = new List<Student>();
            this.CourseName = name;
        }

        public Course(string name, params Student[] students)
            : this(name)
        {
            foreach (var item in students)
            {
                this.AddStudent(item);
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Course name cannot be empty.", "CourseName");
                }

                this.courseName = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count > 30)
            {
                throw new InvalidOperationException("Students in a course cannot be more than 30");
            }

            foreach (var item in students)
            {
                if (item.Name == student.Name)
                {
                    throw new InvalidOperationException("Student is already attending course.");
                }
            }

            this.students.Add(student);
        }

        public void RemoveStudentByUID(int uid)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].GetUID == uid)
                {
                    students.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
