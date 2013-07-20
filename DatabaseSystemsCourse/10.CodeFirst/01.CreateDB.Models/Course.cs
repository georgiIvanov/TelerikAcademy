using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _01.CreateDB.Models
{
    public class Course
    {
        ICollection<Student> students;
        ICollection<Homework> homeworks;

        public Course()
        {
            homeworks = new HashSet<Homework>();
            students = new HashSet<Student>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Materials { get; set; }


        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
