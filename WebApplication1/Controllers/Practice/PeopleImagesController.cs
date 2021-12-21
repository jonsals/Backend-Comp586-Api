//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Models;
//using WebApplication1.ViewModels.PeopleVm;

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PeopleImagesController : ControllerBase
//    {
//        private readonly AlbumContext _context;
//        private readonly IWebHostEnvironment _hostEnvironment;

//        public PeopleImagesController(AlbumContext context, IWebHostEnvironment hostEnvironment)
//        {
//            _context = context;
//            _hostEnvironment = hostEnvironment;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PeopleImage>>> GetPeopleImages()
//        {
//            return await _context.PeopleImages.Select(x => new PeopleImage()
//            {
//                ImageId = x.ImageId,
//                Title = x.Title,
//                ImageFile = x.ImageFile,
//                ImageName = x.ImageName,
//                Occupancy = x.Occupancy,
//                ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)

//            }).ToListAsync();
//        }

//        // GET: api/PeopleImages/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<PeopleImage>> GetPeopleImage(int id)
//        {
//            var peopleImage = await _context.PeopleImages.FindAsync(id);

//            if (peopleImage == null)
//            {
//                return NotFound();
//            }

//            return peopleImage;
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPeopleImage(int id, PeopleImage peopleImage)
//        {
//            if (id != peopleImage.ImageId)
//            {
//                return BadRequest();
//            }

//            if (peopleImage.ImageFile != null)
//            {
//                DeleteImage(peopleImage.ImageName);
//                peopleImage.ImageName = await SaveImage(peopleImage.ImageFile);
//            }
//            _context.Entry(peopleImage).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PeopleImageExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }


//        [HttpPost]
//        public async Task<ActionResult<PeopleImage>> PostPeopleImage([FromForm] PeopleImageVM peopleImage)
//        {
//            if (peopleImage.ImageName != null)
//            {
//                peopleImage.ImageName = await SaveImage(peopleImage.ImageFile);

//            }

//            PeopleImage personI = new()
//            {
//                Title = peopleImage.Title,
//                ImageFile = peopleImage.ImageFile,
//                ImageName = peopleImage.ImageName,
//                Occupancy = peopleImage.Occupancy
//            };
//            _context.PeopleImages.Add(personI);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetPeopleImage", new { id = personI.ImageId }, peopleImage);
//        }

//        // DELETE: api/PeopleImages/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePeopleImage(int id)
//        {
//            var peopleImage = await _context.PeopleImages.FindAsync(id);
//            if (peopleImage == null)
//            {
//                return NotFound();
//            }

//            DeleteImage(peopleImage.ImageName);
//            _context.PeopleImages.Remove(peopleImage);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PeopleImageExists(int id)
//        {
//            return _context.PeopleImages.Any(e => e.ImageId == id);
//        }

//        [NonAction]
//        public async Task<string> SaveImage(IFormFile imageFile)
//        {
//            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
//            imageName = imageName + DateTime.Now.ToString("yy-mm-ss") + Path.GetExtension(imageFile.FileName);
//            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
//            using (var fileStream = new FileStream(imagePath, FileMode.Create))
//            {
//                await imageFile.CopyToAsync(fileStream);
//            }
//            return imageName;
//        }

//        [NonAction]
//        public void DeleteImage(string imageName)
//        {
//            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

//            if (System.IO.File.Exists(imagePath))
//            {
//                System.IO.File.Delete(imagePath);
//            }


//        }
//    }
//}
