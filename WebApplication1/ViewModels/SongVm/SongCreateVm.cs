using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.SongVm
{
    public class SongCreateVm
    {

        public string SongName { get; set; }
        public int Minute { get; set; }
        public int Seconds { get; set; }
        public int AlbumId { get; set; }
    }
}
