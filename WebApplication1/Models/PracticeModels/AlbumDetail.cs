using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AlbumDetail
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string AlbumTitle { get; set; }
        public string AlbumArtist { get; set; }
        public int TotalSongs { get; set; }
    }
}
