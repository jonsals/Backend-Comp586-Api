using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SomethingPeople
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FavoriteFood { get; set; }
        [Required]
        public int Age { get; set; }

        public enum Size { Short, Average, tall }
        public Size DifferentSize { get; set; }

        [Required]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public ICollection<People> peopleName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
