using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _01.MusicStoreModels
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public string Producer { get; set; }

        public virtual IList<Artist> Artists { get; set; }
        public virtual IList<Song> Songs { get; set; }
    }
}