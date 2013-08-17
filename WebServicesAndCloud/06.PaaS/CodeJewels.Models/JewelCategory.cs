using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Models
{
    public class JewelCategory
    {
        public int Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string Category { get; set; }
    }
}
