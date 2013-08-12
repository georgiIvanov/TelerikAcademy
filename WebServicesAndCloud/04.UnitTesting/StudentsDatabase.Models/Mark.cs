using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Models
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }
    }
}
