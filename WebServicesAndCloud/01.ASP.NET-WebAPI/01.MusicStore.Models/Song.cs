using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _01.MusicStoreModels
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string Title { get; set; }
        public virtual DateTime? Year { get; set; }
        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}