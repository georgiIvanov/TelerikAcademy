using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01.CreateDB.Models
{
    public class Homework
    {
        public Homework()
        {

        }

        [Key]
        public int HomeworkId { get; set; }
        
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public string Content { get; set; }
        
        public DateTime TimeSent { get; set; }
    }
}
