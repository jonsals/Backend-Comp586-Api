using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels.PeopleVm
{
    public class PeopleCreateVm
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public byte[] image { get; set; }
    }
}
