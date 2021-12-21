using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.ArtistVm
{
    public class ArtistUploadVm
    {
        
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }

        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageUrl { get; set; }
    }
}
