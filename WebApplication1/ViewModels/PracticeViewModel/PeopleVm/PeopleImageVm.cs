using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.PeopleVm
{
    public class PeopleImageVM
    {


        public string Title { get; set; }

        public string Occupancy { get; set; }

        public string ImageName { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
