using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AlbumImageVm
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string ImageUrl { get; set; }
    }
}
