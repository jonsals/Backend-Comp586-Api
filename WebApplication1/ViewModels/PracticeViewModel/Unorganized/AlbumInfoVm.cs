using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AlbumInfoVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double RegularPrice { get; set; }
        public string Details { get; set; }
        private ICollection<AlbumImageVm> AlbumImages { get; set; }
    }
}
