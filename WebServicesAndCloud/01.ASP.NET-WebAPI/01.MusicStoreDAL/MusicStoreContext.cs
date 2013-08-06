using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.MusicStoreModels;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _01.MusicStoreDAL
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
            : base("MusicStoreDb")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Artist>()
            //    .HasRequired(x => x.Name)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Album>()
            //    .HasRequired(x => x.Title)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Song>()
            //    .HasRequired(x => x.Title)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
