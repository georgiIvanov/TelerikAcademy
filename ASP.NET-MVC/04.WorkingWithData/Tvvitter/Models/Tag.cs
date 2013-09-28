using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tvvitter.Models
{
    public class Tag
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }
        [Key]
        [Required(ErrorMessage="Tag must have a name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Tag name must be between 1 and 50 symbols")]
        public string Name { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        
    }
}