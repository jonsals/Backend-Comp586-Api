using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication1.Models
{
    public partial class AlbumInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double RegularPrice { get; set; }
        public int TotalNumberOfSongs { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("PersonId")]
        public ICollection<ArtistInfo> Artist { get; set; }
        public string ImageUrl { get; set; }


    }
}


