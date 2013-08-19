using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

        public Category()
        {
            this.Threads = new HashSet<Thread>();
        }
    }
}
