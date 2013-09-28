using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tvvitter.Models
{
    public class Tweet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage="You must enter a message, to post a tweet")]
        [StringLength(300,MinimumLength=5,ErrorMessage="Message length must be between 5 and 300 symbols")]
        public string Message { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; }
    }
}