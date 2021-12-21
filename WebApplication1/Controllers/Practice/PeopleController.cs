//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using WebApplication1.Models;
//using WebApplication1.ViewModels.PeopleVm;


////For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PeopleController : ControllerBase
//    {


//        private readonly AlbumContext _context;

//        public PeopleController(AlbumContext context)
//        {
//            _context = context;
//        }

//        //GET: api/<PeopleController>
//        [HttpGet]
//        public async Task<List<PeopleNameVm>> Get()
//        {
//            IQueryable<PeopleNameVm> people = _context.PeopleName.Where(a => a.Id > 0).Select(a => new PeopleNameVm
//            {
//                Id = a.Id,
//                Name = a.Name,
//                LastName = a.LastName,
//                RandomId = a.RandomId,
//                Image = a.Image
//            });
//            return await people.ToListAsync();
//        }

//        [HttpGet("{Peopleid:int}", Name = "DifferName")]
//        public async Task<List<PeopleNameVm> >Get(int Peopleid)
//        {
//            IQueryable<PeopleNameVm> othername = _context.PeopleName.Where(a => a.Id == Peopleid).Select(a => new PeopleNameVm
//            {
//                Id = a.Id,
//                Name = a.Name,
//                LastName = a.LastName,
//                Image = a.Image,
//                RandomId = a.RandomId,
//            });
//            return await othername.ToListAsync();

//        }

//        [HttpPost]
//        [Route("Create")]
//        public async Task<IActionResult> Post([FromBody] PeopleCreateVm people)
//        {
//            bool value = _context.PeopleName.Any(a => a.Name == people.Name);
//            if (people == null) return BadRequest(ModelState);
//            if (value)
//            {
//                ModelState.AddModelError("", "This name exist");
//                return StatusCode(404, ModelState);
//            }
//            if (!ModelState.IsValid) return BadRequest();
//            Random rnd = new Random();

//            People newName = new()
//            {
//                Name = people.Name,
//                LastName = people.LastName,
//                RandomId = rnd.Next(1, 10)
//            };
//            await _context.PeopleName.AddAsync(newName);
//            await _context.SaveChangesAsync();

//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            bool value = _context.PeopleName.Any(a => a.Id == id);
//            if (!value)
//            {
//                return NotFound();
//            }
//            _context.Remove(_context.PeopleName.Single(a => a.Id == id));
//            await _context.SaveChangesAsync();
//            return Ok();
//        }



//        [HttpPatch]
//        [Route("Update")]
//        public async Task<IActionResult> updateNames(int id, [FromBody] PeopleUpdateVm person)
//        {
//            if (id != person.Id || person == null) return BadRequest();

//            bool value = _context.PeopleName.Any(a => a.Name == person.Name);
//            if (value)
//            {
//                ModelState.AddModelError("", "There name exist");
//                return StatusCode(404, ModelState);
//            }
//            if (!ModelState.IsValid) return BadRequest();

//            People updatePerson = new()
//            {
//                Id = id,
//                Name = person.Name,
//                LastName = person.LastName,
//            };
//            _context.PeopleName.Update(updatePerson);
//            await _context.SaveChangesAsync();
//            return Ok();
//        }

//    }
//}


////}

////public async Task<IActionResult> Get(int id)
////{
////    People obj = await _context.PeopleName.FirstOrDefaultAsync(a => a.Id == id);
////    if (obj == null)
////    {
////        return NotFound();
////    }

////    return Ok(obj);

////}

////POST api/<PeopleController>

////[HttpPost]
////[Route("Create")]
////public async Task<IActionResult> Create(string fName, string lastname)
////{
////    Random rnd = new Random();
////    People newP = new()
////    {
////        Name = fName,
////        LastName = lastname,
////        RandomId = rnd.Next(1, 10)
////    };
////    await _context.AddAsync(newP);
////    _context.SaveChanges();
////    return Ok();
////}
//////public async Task<IActionResult> Create(string fName, string lastname)
//////{
//////    Random rnd = new Random();
//////    People newP = new()
//////    {
//////        Name = fName,
//////        LastName = lastname,
//////        RandomId = rnd.Next(1, 10)
//////    };
//////    await _context.AddAsync(newP);
//////    _context.SaveChanges();
//////    return Ok();
//////}
/////
////public async Task<IActionResult> Post([FromBody] People people)
////{
////    bool value = _context.PeopleName.Any(a => a.Name == people.Name);
////    if (people == null) return BadRequest(ModelState);
////    if (value)
////    {
////        ModelState.AddModelError("", "There exist this name");
////        return StatusCode(404, ModelState);
////    }
////    if (!ModelState.IsValid) return BadRequest();
////    await Create(people.Name, people.LastName);
////    return Ok();
////}


////DELETE api/<PeopleController>/5
////public async Task<List<People>> Get()
////{
////    IQueryable<People> peoples = _context.PeopleName.Where(a => a.Id > 0);
////    return await peoples.ToListAsync();
////}



////GET api/<PeopleController>/5