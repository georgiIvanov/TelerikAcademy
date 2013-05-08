using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        Dictionary<int, Student> students;
        List<Course> courses;

        public School()
        {
            students = new Dictionary<int, Student>();
            courses = new List<Course>();
        }

        public Student GetStudentByUID(int uid)
        {
            Student stud;
            students.TryGetValue(uid, out stud);
            if (stud == null)
            {
                throw new ArgumentException("No student with such unique id.", "uid");
            }
            return stud;    
        }

        public Course GetCourseByName(string name)
        {
            foreach (var item in courses)
            {
                if (item.CourseName == name)
                {
                    return item;
                }
            }
            throw new InvalidOperationException("No such course");
        }

        public void AddStudent(string name, int uid)
        {
            if (students.ContainsKey(uid))
            {
                throw new ArgumentException("Student with same unique id already exists", "uid");
            }

            students.Add(uid, new Student(name, uid));
        }

        public void AddCourse(Course course)
        {
            string courseName = course.CourseName;
            foreach (var item in courses)
            {
                if (item.CourseName == courseName)
                {
                    throw new ArgumentException("Course names cannot duplicate.");
                }
            }

            courses.Add(course);
        }

        public void AddCourse(string name, params Student[] students)
        {
            courses.Add(new Course(name, students));
        }

    }
}
