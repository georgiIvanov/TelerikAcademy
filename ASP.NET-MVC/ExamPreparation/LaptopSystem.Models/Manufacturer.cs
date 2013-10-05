using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Manufacturer
    {
        [Key]
        public virtual int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength=1)]
        public virtual string Name { get; set; }
        public virtual ICollection<Laptop> Laptops { get; set; }

        public Manufacturer()
        {
        }
    }
}
