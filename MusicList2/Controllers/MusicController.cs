using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicList2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicList2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string titleFilter, string artistFilter, int? yearFilter, int? ratingFilter)
        {
            var query = _context.Music.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(titleFilter))
            {
                query = query.Where(m => m.Title.Contains(titleFilter));
            }

            if (!string.IsNullOrEmpty(artistFilter))
            {
                query = query.Where(m => m.Artist.Contains(artistFilter));
            }

            if (yearFilter.HasValue)
            {
                query = query.Where(m => m.Year == yearFilter);
            }

            if (ratingFilter.HasValue)
            {
                query = query.Where(m => m.Rating == ratingFilter);
            }

            var musicList = await query.ToListAsync();

            return (IActionResult)musicList;
        }








        [HttpGet]
        public async Task<ActionResult<IQueryable<Music>>> GetMusic()
        {
            var musicList = await _context.Music.ToListAsync();
            return Ok(musicList);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusicById(int id)
        {
            var music = await _context.Music.FindAsync(id);

            if (music == null)
            {
                return NotFound(); 
            }

            return Ok(music);
        }

        
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicById), new { id = music.MusicId }, music); 
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, Music music)
        {
            if (id != music.MusicId)
            {
                return BadRequest(); 
            }

            _context.Entry(music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); 
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound(); 
            }

            _context.Music.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.MusicId == id);
        }
    }
}
