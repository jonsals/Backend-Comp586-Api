// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AlbumContext))]
    [Migration("20211220184910_changedImageAlbum")]
    partial class changedImageAlbum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.AlbumInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RegularPrice")
                        .HasColumnType("float");

                    b.Property<int>("TotalNumberOfSongs")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumInfos");
                });

            modelBuilder.Entity("WebApplication1.Models.ArtistInfo", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId");

                    b.HasIndex("PersonId");

                    b.ToTable("ArtistInfos");
                });

            modelBuilder.Entity("WebApplication1.Models.SongInfo", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.ToTable("SongInfos");
                });

            modelBuilder.Entity("WebApplication1.Models.AlbumInfo", b =>
                {
                    b.HasOne("WebApplication1.Models.SongInfo", null)
                        .WithMany("AlbumInfo")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("WebApplication1.Models.ArtistInfo", b =>
                {
                    b.HasOne("WebApplication1.Models.AlbumInfo", null)
                        .WithMany("Artist")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("WebApplication1.Models.AlbumInfo", b =>
                {
                    b.Navigation("Artist");
                });

            modelBuilder.Entity("WebApplication1.Models.SongInfo", b =>
                {
                    b.Navigation("AlbumInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
