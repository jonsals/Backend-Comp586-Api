using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SongInfo
    {
        [Key]
        public int SongId { get; set; }
        [Required]
        public string SongName { get; set; }
        [Required]
        public int Minute { get; set; }
        [Required]
        public int Seconds { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public ICollection<AlbumInfo> AlbumInfo { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
