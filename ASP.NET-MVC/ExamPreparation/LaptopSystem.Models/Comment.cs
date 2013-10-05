using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Laptop Laptop { get; set; }
        [StringLength(300, MinimumLength=2)]
        public virtual string Content { get; set; }
    }
}
