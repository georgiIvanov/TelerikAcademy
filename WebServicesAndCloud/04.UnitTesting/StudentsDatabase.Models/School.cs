using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Models
{
    public class School
    {
        public School()
        {
            //this.Students = new HashSet<Student>();
        }

        [Key]
        public int SchoolId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
