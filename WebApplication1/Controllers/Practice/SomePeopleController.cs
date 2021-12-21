//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication1.Models;
//using WebApplication1.ViewModels;
//using WebApplication1.ViewModels.PeopleVm;

////For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SomePeopleController : ControllerBase
//    {


//        private readonly AlbumContext _context;

//        public SomePeopleController(AlbumContext context)
//        {
//            _context = context;
//        }

//        //GET: api/<PeopleController>
//        [HttpGet]
//        public async Task<List<SomethingPeopleVm>> Get()
//        {
//            IQueryable<SomethingPeopleVm> people = _context.SomethingPeoples.Where(a => a.Id > 0).Select(a => new SomethingPeopleVm
//            {
//                Id = a.Id,
//                FavoriteFood = a.FavoriteFood,
//                Age = a.Age,
//                DifferentSize = a.DifferentSize,
//                PersonId = a.PersonId,
//                peopleName = _context.PeopleName.Where(c => c.Id == a.PersonId).Select(c => new PeopleNameVm()
//                {
//                    Id = c.Id,
//                    Name = c.Name,
//                    LastName = c.LastName,
//                    RandomId =c.RandomId,
//                    Image = c.Image
                    
//                }).ToList()
//            });
//            return await people.ToListAsync();
//        }

//        [HttpGet("{Someid:int}", Name = "other")]
//        public async Task<IActionResult> Get(int Someid)
//        {
//            SomethingPeople people = await _context.SomethingPeoples.FirstOrDefaultAsync(a => a.Id == Someid);
//            if (people == null)
//            {
//                return NotFound();
//            }

//            IQueryable<SomethingPeopleVm> nameList = _context.SomethingPeoples.Where(a => a.Id == Someid).Select(c => new SomethingPeopleVm
//            {
//                Id = c.Id,
//                FavoriteFood = c.FavoriteFood,
//                Age = c.Age,
//                DifferentSize = c.DifferentSize,
//                PersonId = c.PersonId,
//                peopleName = _context.PeopleName.Where(a => a.Id == c.PersonId).Select(a => new PeopleNameVm()
//                {
//                    Name = a.Name,
//                    LastName = a.LastName,
//                    Id = a.Id,
//                    Image =a.Image,
//                    RandomId = a.RandomId
//                }).ToList()
//            });


//            return Ok(nameList);

//        }

//        //[HttpPost]
//        //[Route("Create")]
//        //public async Task<IActionResult> Post([FromBody] SPCreate people)
//        //{
//        //    bool value = _context.SomethingPeoples.Any(a => a.FavoriteFood == people.FavoriteFood);
//        //    if (people == null) return BadRequest(ModelState);
//        //    if (value)
//        //    {
//        //        ModelState.AddModelError("", "This name exist");
//        //        return StatusCode(404, ModelState);
//        //    }
//        //    if (!ModelState.IsValid) return BadRequest();

//        //    SomethingPeople newName = new()
//        //    {
//        //        FavoriteFood = people.FavoriteFood,
//        //        Age = people.Age,
//        //        DifferentSize = people.DifferentSize,
//        //        PersonId = people.PersonId,
//        //    };
//        //    await _context.SomethingPeoples.AddAsync(newName);
//        //    await _context.SaveChangesAsync();

//        //    return Ok();
//        //}



//        [HttpPost]
//        [Route("Create")]
//        public async Task<IActionResult> Post([FromBody] SPCreate people)
//        {
//            bool value = _context.PeopleName.Any(a => a.Id == people.PersonId);
//            Console.WriteLine(value);
//            if (people == null) return BadRequest(ModelState);
//            if (!value)
//            {
//                ModelState.AddModelError("", "Please select a name");
//                return StatusCode(404, ModelState);
//            }
//            if (!ModelState.IsValid) return BadRequest();
//            Random rnd = new Random();

//            SomethingPeople newName = new()
//            {
//                FavoriteFood = people.FavoriteFood,
//                Age = people.Age,
//                DifferentSize = (SomethingPeople.Size)people.DifferentSize,
//                //DifferentSize = JsonConvert.DeserializeObject<SPCreate>(people.DifferentSize)
//                PersonId = people.PersonId,
//            };
//            await _context.SomethingPeoples.AddAsync(newName);
//            await _context.SaveChangesAsync();

//            return Ok();
//        }



//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            bool value = _context.SomethingPeoples.Any(a => a.Id == id);
//            if (!value)
//            {
//                return NotFound();
//            }
//            _context.Remove(_context.SomethingPeoples.Single(a => a.Id == id));
//            await _context.SaveChangesAsync();
//            return Ok();
//        }



//        [HttpPatch]
//        [Route("Update")]
//        public async Task<IActionResult> updateNames(int id, [FromBody] SPUpdate person)
//        {
//            if (id != person.Id || person == null) return BadRequest();

//            bool value = _context.SomethingPeoples.Any(a => a.FavoriteFood == person.FavoriteFood);
//            if (value)
//            {
//                ModelState.AddModelError("", "There name exist");
//                return StatusCode(404, ModelState);
//            }
//            if (!ModelState.IsValid) return BadRequest();

//            SomethingPeople updatePerson = new()
//            {
//                Id = id,
//                FavoriteFood = person.FavoriteFood,
//                Age = person.Age,
//                DifferentSize = person.DifferentSize,
//                PersonId = person.PersonId,
//            };
//            _context.SomethingPeoples.Update(updatePerson);
//            await _context.SaveChangesAsync();
//            return Ok();
//        }

//    }


//}

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