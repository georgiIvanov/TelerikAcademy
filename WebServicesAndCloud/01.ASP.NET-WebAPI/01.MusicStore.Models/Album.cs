using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _01.MusicStoreModels
{
    public class Album
    {
        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string Title { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}