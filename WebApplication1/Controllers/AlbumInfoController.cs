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
using WebApplication1.ViewModels.AlbumVm;
using WebApplication1.ViewModels.PeopleVm;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumInfoController : ControllerBase
    {
        private readonly AlbumContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AlbumInfoController(AlbumContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/AlbumInfo
        [HttpGet]
        //[Authorize]
        public async Task<List<AlbumInfo>> Get()
        {
            IQueryable<AlbumInfo> album = _context.AlbumInfos.Where(a => a.Id > 0).Select(x=> new AlbumInfo
            {
                Id = x.Id,
                Name = x.Name,
                RegularPrice = x.RegularPrice,
                TotalNumberOfSongs = x.TotalNumberOfSongs,
                ArtistId = x.ArtistId,
                ImageUrl = x.ImageUrl,
                Artist = _context.ArtistInfos.Where(c => c.ArtistId == x.ArtistId).Select(c => new ArtistInfo()
                {
                    ArtistId = c.ArtistId,
                    Name = c.Name,
                    Genre = c.Genre,
                    ImageName = c.ImageName,
                    ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, c.ImageName),

                }).ToList()
            });

        return await album.ToListAsync();
        }

        






        [HttpGet("{Someid:int}", Name = "other")]
        //[Authorize]
        public async Task<IActionResult> Get(int Someid)
        {
            AlbumInfo people = await _context.AlbumInfos.FirstOrDefaultAsync(a => a.Id == Someid);
            if (people == null)
            {
                return NotFound();
            }


            IQueryable<AlbumInfo> album = _context.AlbumInfos.Where(a => a.Id == Someid).Select(x=> new AlbumInfo
            {
                Id = x.Id,
                Name = x.Name,
                RegularPrice = x.RegularPrice,
                TotalNumberOfSongs = x.TotalNumberOfSongs,
                ArtistId = x.ArtistId,
                ImageUrl = x.ImageUrl,
                Artist = _context.ArtistInfos.Where(c => c.ArtistId == x.ArtistId).Select(c => new ArtistInfo()
                {
                    ArtistId = c.ArtistId,
                    Name = c.Name,
                    Genre = c.Genre,
                    ImageName = c.ImageName,
                    ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, c.ImageName),

                }
                
                ).ToList()
            });
            return Ok(album);

        }









        [HttpPatch]
        //[Authorize]
        [Route("Update")]
        public async Task<IActionResult> updateNames(int id, AlbumUpdateVm album)
        {
            if (id != album.Id || album == null) return BadRequest();

           
            if (!ModelState.IsValid) return BadRequest();

            if (album.ImageUrl == null)
            {
                return BadRequest();
            }

            AlbumInfo updateAlbum = new()
            {
                Id = album.Id,
                Name = album.Name,
                RegularPrice = album.RegularPrice,
                TotalNumberOfSongs = album.TotalNumberOfSongs,
                ArtistId = album.ArtistId,
                ImageUrl = album.ImageUrl,

            };
            _context.AlbumInfos.Update(updateAlbum);
            await _context.SaveChangesAsync();
            return Ok();
        }




        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<AlbumInfo>> PostAlbumInfo(AlbumCreateVm albumInfo)
        {


            AlbumInfo newAlbum = new AlbumInfo()
            {
                Name = albumInfo.Name,
                RegularPrice = albumInfo.RegularPrice,
                TotalNumberOfSongs = albumInfo.TotalNumberOfSongs,
                ImageUrl =albumInfo.ImageUrl,
                ArtistId = albumInfo.ArtistId,           
            };


            _context.AlbumInfos.Add(newAlbum);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/AlbumInfo/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteAlbumInfo(int id)
        {
            var albumInfo = await _context.AlbumInfos.FindAsync(id);
            if (albumInfo == null)
            {
                return NotFound();
            }
            
            _context.AlbumInfos.Remove(albumInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumInfoExists(int id)
        {
            return _context.AlbumInfos.Any(e => e.Id == id);
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
