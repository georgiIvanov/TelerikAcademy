using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Laptop
    {
        public virtual int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100, MinimumLength = 1)]
        public virtual string Model { get; set; }
        [Required]
        public virtual double Inches { get; set; }
        [Required]
        public virtual double Harddisk { get; set; }
        [Required]
        public virtual double Ram { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [RegularExpression(@"https?:\/\/.*\.(?:png|jpg)")]
        public virtual string Image { get; set; }
        [Required]
        [Column(TypeName="money")]
        public virtual Decimal Price { get; set; }
        public virtual double Weight { get; set; }
        [StringLength(500, MinimumLength=5)]
        public virtual string AdditionalParts { get; set; }
        [StringLength(500, MinimumLength=5)]
        public virtual string Description { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public Laptop()
        {
            
        }
    }
}
