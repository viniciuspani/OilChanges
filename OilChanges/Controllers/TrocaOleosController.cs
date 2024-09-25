using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OilChanges.Context;
using OilChanges.Shared.Model;

namespace OilChanges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrocaOleosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrocaOleosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TrocaOleos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrocaOleo>>> GetTrocaOleos()
        {
            if (_context.TrocaOleos == null)
            {
                return NotFound();
            }
            return await _context.TrocaOleos.ToListAsync();
        }

        // GET: api/TrocaOleos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrocaOleo>> GetTrocaOleo(int id)
        {
            if (_context.TrocaOleos == null)
            {
                return NotFound();
            }
            var trocaOleo = await _context.TrocaOleos.FindAsync(id);

            if (trocaOleo == null)
            {
                return NotFound();
            }

            return trocaOleo;
        }

        // PUT: api/TrocaOleos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrocaOleo(int id, TrocaOleo trocaOleo)
        {
            if (id != trocaOleo.TrocaOleoId)
            {
                return BadRequest();
            }

            _context.Entry(trocaOleo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrocaOleoExists(id))
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

        // POST: api/TrocaOleos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrocaOleo>> PostTrocaOleo(TrocaOleo trocaOleo)
        {
            if (_context.TrocaOleos == null)
            {
                return Problem("Entity set 'AppDbContext.TrocaOleos'  is null.");
            }
            _context.TrocaOleos.Add(trocaOleo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrocaOleo", new { id = trocaOleo.TrocaOleoId }, trocaOleo);
        }

        // DELETE: api/TrocaOleos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrocaOleo(int id)
        {
            if (_context.TrocaOleos == null)
            {
                return NotFound();
            }
            var trocaOleo = await _context.TrocaOleos.FindAsync(id);
            if (trocaOleo == null)
            {
                return NotFound();
            }

            _context.TrocaOleos.Remove(trocaOleo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrocaOleoExists(int id)
        {
            return (_context.TrocaOleos?.Any(e => e.TrocaOleoId == id)).GetValueOrDefault();
        }
    }
}
