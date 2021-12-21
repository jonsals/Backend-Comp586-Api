using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PeopleImage
    {
        [Key]
        public int ImageId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Occupancy { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageUrl { get; set; }
    }
}



