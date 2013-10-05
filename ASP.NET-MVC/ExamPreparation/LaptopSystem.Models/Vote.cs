using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class Vote
    {
        public virtual int Id { get; set; }
        public virtual Laptop Laptop {get; set;}
        public virtual ApplicationUser User { get; set; }
    }
}
