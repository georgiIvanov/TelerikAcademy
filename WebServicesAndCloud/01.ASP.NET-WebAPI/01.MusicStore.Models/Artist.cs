using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _01.MusicStoreModels
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }

        public virtual IList<Album> Albums { get; set; }
    }
}