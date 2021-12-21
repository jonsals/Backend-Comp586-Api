using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication1.Models
{
    public partial class AlbumImage
    {
        [Key]
        public int Id { get; set; }
        public int AlbumImageId { get; set; }
        public string AlbumImageUrl { get; set; }
        public byte[] ImageData { get; set; }
        public virtual AlbumInfo Album { get; set; }
    }
}



