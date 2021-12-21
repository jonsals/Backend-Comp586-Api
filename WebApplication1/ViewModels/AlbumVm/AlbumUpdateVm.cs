using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.AlbumVm
{
    public class AlbumUpdateVm
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double RegularPrice { get; set; }
        public int TotalNumberOfSongs { get; set; }
        public int ArtistId { get; set; }
        public string ImageUrl { get; set; }
    }
}
