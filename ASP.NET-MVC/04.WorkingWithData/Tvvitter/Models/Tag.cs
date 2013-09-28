using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tvvitter.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Tag must have a name")]
        [StringLength(50,MinimumLength=1,ErrorMessage="Tag name must be between 1 and 50 symbols")]
        public string Name { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}