using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels.SongVm
{
    public class SongGetVm
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int Minute { get; set; }
        public int Seconds { get; set; }
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public ICollection<AlbumInfo> AlbumInfo { get; set; }
    }
}
