using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.AlbumVm
{
    public class AlbumCreateVm
    {

        public string Name { get; set; }
        public double RegularPrice { get; set; }
        public int TotalNumberOfSongs { get; set; }
        public int ArtistId { get; set; }
        public string ImageUrl { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
    }
}
