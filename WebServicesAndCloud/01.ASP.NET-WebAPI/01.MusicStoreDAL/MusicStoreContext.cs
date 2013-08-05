using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.MusicStoreModels;

namespace _01.MusicStoreDAL
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
            : base("MusicStoreDb")
        {
            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
            
    }
}
