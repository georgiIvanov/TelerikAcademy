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
    [DataContract]
    public class CodeJewel
    {
        public int Id { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        [ForeignKey("JewelCategory")]
        public int CategoryId { get; set; }

        [DataMember]
        public virtual JewelCategory JewelCategory { get; set; }

        [DataMember]
        public string AuthorEmail { get; set; }

        [DataMember]
        public int Rating { get; set; }

        [Required]
        [DataMember(IsRequired = true)]
        public string Content { get; set; }
    }
}
