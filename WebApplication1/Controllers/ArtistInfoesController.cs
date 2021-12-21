using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels.ArtistVm;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArtistInfoController : ControllerBase
    {
        private readonly AlbumContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArtistInfoController(AlbumContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment; 
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ArtistInfo>>> GetArtistInfos()
        {
            return await _context.ArtistInfos.Select(x => new ArtistInfo()
            {
                ArtistId = x.ArtistId,
                Name = x.Name,
                Genre = x.Genre,
                ImageFile = x.ImageFile,
                ImageName = x.ImageName,
                ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)

            }).ToListAsync();
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetArtistInfo(int id)
        {
            var artistInfo = await _context.ArtistInfos.FirstOrDefaultAsync(a=>a.ArtistId ==id);

            if (artistInfo == null)
            {
                return NotFound();
            }
            //Need a view Model
            return Ok(artistInfo);
        }




        [HttpPatch]
        //[Authorize]
        [Route("Update")]
        public async Task<IActionResult> updateNames(int id, [FromForm] ArtistUploadVm person)
        {
            if (id != person.ArtistId || person == null) return BadRequest();

            bool value = _context.ArtistInfos.Any(a => a.Name == person.Name);
            if (value)
            {
                ModelState.AddModelError("", "There name exist");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest();

            if (person.ImageName != null)
            {
                person.ImageName = await SaveImage(person.ImageFile);
            }

            ArtistInfo updatePerson = new()
            {
                ArtistId = person.ArtistId,
                Name = person.Name,
                Genre = person.Genre,
                ImageName = person.ImageName,
                ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, person.ImageName)
            };
            _context.ArtistInfos.Update(updatePerson);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ArtistInfo>> PostArtistInfo([FromForm]ArtistCreateVm artistInfo)
        {
            
            if(artistInfo.ImageName !=null)
            {
                artistInfo.ImageName = await SaveImage(artistInfo.ImageFile);
            }

            ArtistInfo newArtist = new()
            {
                Name = artistInfo.Name,
                Genre = artistInfo.Genre,
                ImageName = artistInfo.ImageName,
            };

            _context.ArtistInfos.Add(newArtist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistInfo", new { id = newArtist.ArtistId }, artistInfo);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteArtistInfo(int id)
        {
            var artistInfo = await _context.ArtistInfos.FindAsync(id);
            if (artistInfo == null)
            {
                return NotFound();
            }
            if (artistInfo.ImageName != null)
            {
                DeleteImage(artistInfo.ImageName);
            }
            


            _context.ArtistInfos.Remove(artistInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistInfoExists(int id)
        {
            return _context.ArtistInfos.Any(e => e.ArtistId == id);
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yy-mm-ss") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }


        }
    }
}
