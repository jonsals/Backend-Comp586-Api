using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.Models
{
    public partial class AlbumContext : DbContext
    {
        public AlbumContext()
        {
        }

        public AlbumContext(DbContextOptions<AlbumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlbumInfo> AlbumInfos { get; set; }

        //public virtual DbSet<AlbumImage> AlbumImages { get; set; }

        //public virtual DbSet<People> PeopleName { get; set; }
        //public virtual DbSet<SomethingPeople> SomethingPeoples { get; set; }
        //public virtual DbSet<PeopleImage> PeopleImages { get; set; }
        public virtual DbSet<SongInfo> SongInfos { get; set; }
        public virtual DbSet<ArtistInfo> ArtistInfos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AlbumInfo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
