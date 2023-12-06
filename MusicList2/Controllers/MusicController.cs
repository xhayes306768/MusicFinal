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

        // GET: api/Music
        [HttpGet]
        public async Task<ActionResult<IQueryable<Music>>> GetMusic()
        {
            var musicList = await _context.Music.ToListAsync();
            return Ok(musicList);
        }

        // GET: api/Music/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusicById(int id)
        {
            var music = await _context.Music.FindAsync(id);

            if (music == null)
            {
                return NotFound(); // Return 404 Not Found
            }

            return Ok(music);
        }

        // POST: api/Music
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            _context.Music.Add(music);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMusicById), new { id = music.MusicId }, music); // Return 201 Created
        }

        // PUT: api/Music/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusic(int id, Music music)
        {
            if (id != music.MusicId)
            {
                return BadRequest(); // Return 400 Bad Request
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
                    return NotFound(); // Return 404 Not Found
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Return 204 No Content
        }

        // DELETE: api/Music/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound(); // Return 404 Not Found
            }

            _context.Music.Remove(music);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content
        }

        private bool MusicExists(int id)
        {
            return _context.Music.Any(e => e.MusicId == id);
        }
    }
}
