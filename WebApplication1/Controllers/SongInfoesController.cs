using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels.PeopleVm;
using WebApplication1.ViewModels.SongVm;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongInfoController : ControllerBase
    {
        private readonly AlbumContext _context;

        public SongInfoController(AlbumContext context)
        {
            _context = context;
        }

        // GET: api/SongInfoes
        [HttpGet]
        //[Authorize]
        public async Task<List<SongGetVm>> GetSongInfos()
        {
            IQueryable<SongGetVm> song = _context.SongInfos.Where(a => a.SongId > 0).Select(a => new SongGetVm
            {
                SongId = a.SongId,
                SongName = a.SongName,
                Minute = a.Minute,
                Seconds = a.Seconds,
                AlbumId = a.AlbumId,
                AlbumInfo = _context.AlbumInfos.Where(c => c.Id == a.AlbumId).Select(x => new AlbumInfo()
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegularPrice = x.RegularPrice,
                    TotalNumberOfSongs = x.TotalNumberOfSongs,
                    ArtistId = x.ArtistId,
                    ImageUrl = x.ImageUrl,
                    Artist = _context.ArtistInfos.Where(y => y.ArtistId == x.ArtistId).Select(y => new ArtistInfo()
                    {
                        ArtistId = y.ArtistId,
                        Name = y.Name,
                        Genre = y.Genre,
                        ImageName = y.ImageName,
                        ImageUrl = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, y.ImageName),

                    }).ToList()

                }).ToList()
            }) ;


            return await song.ToListAsync();

        }



        // GET: api/SongInfoes/5
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<SongInfo>> GetSongInfo(int id)
        {
            var songInfo = await _context.SongInfos.FindAsync(id);

            if (songInfo == null)
            {
                return NotFound();
            }

            return songInfo;
        }


        [HttpPatch]
        [Authorize]
        [Route("Update")]
        public async Task<IActionResult> updateNames(int id, SongUpdateVm Song)
        {
            if (id != Song.SongId || Song == null) return BadRequest();


            if (!ModelState.IsValid) return BadRequest();

            SongInfo updateSong = new()
            {
                SongId = Song.SongId,
                SongName = Song.SongName,
                Minute = Song.Minute,
                Seconds = Song.Seconds,
                AlbumId = Song.AlbumId

            };
            _context.SongInfos.Update(updateSong);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<SongInfo>> PostSongInfo(SongCreateVm songInfo)
        {
            SongInfo newSong = new SongInfo()
            {
                SongName = songInfo.SongName,
                Minute = songInfo.Minute,
                Seconds = songInfo.Seconds,
                AlbumId = songInfo.AlbumId
            };
            _context.SongInfos.Add(newSong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongInfo", new { id = newSong.SongId }, songInfo);
        }

        // DELETE: api/SongInfoes/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteSongInfo(int id)
        {
            var songInfo = await _context.SongInfos.FindAsync(id);
            if (songInfo == null)
            {
                return NotFound();
            }

            _context.SongInfos.Remove(songInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongInfoExists(int id)
        {
            return _context.SongInfos.Any(e => e.SongId == id);
        }
    }
}
