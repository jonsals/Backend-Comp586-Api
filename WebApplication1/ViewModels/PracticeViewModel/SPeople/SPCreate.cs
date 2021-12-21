using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModels.PeopleVm;
using static WebApplication1.Models.SomethingPeople;

namespace WebApplication1.ViewModels
{
    public class SPCreate
    {
            public string FavoriteFood { get; set; }
            [Required]
            public int Age { get; set; }

            public int DifferentSize { get; set; }

            [Required]
            public int PersonId { get; set; }
        
    }
}
