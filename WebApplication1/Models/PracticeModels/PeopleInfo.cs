using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication1.Models
{
    public partial class People
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RandomId { get; set; }
        public byte[] Image { get; set; }

    }
}


