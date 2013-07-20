using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _01.CreateDB.Models
{
    public class Student
    {
        ICollection<Course> courses;
        ICollection<Homework> homeworks;

        public Student()
        {
            courses = new HashSet<Course>();
            homeworks = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

    }
}
