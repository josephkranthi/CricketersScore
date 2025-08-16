using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketersScore.Server.Model;

namespace CricketersScore.Server.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class CricketersController : ControllerBase
    {
        private readonly TestContext _context;

        public CricketersController(TestContext context)
        {
            _context = context;
        }

        // GET: /Cricketers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cricketer>>> GetCricketers()
        {
            return await _context.Cricketers.ToListAsync();
        }

        // GET: /Cricketers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cricketer>> GetCricketer(int id)
        {
            var cricketer = await _context.Cricketers.FindAsync(id);

            if (cricketer == null)
            {
                return NotFound();
            }

            return cricketer;
        }

        // PUT: /Cricketers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCricketer(int id, [FromBody] Cricketer cricketer)
        {
            if (id != cricketer.Rank)
            {
                return BadRequest();
            }

            _context.Entry(cricketer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CricketerExists(id))
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

        // POST: /Cricketers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cricketer>> PostCricketer([FromBody] Cricketer cricketer)
        {
            _context.Cricketers.Add(cricketer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CricketerExists(cricketer.Rank))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCricketer", new { id = cricketer.Rank }, cricketer);
        }

        // DELETE: /Cricketers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCricketer(int id)
        {
            var cricketer = await _context.Cricketers.FindAsync(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            _context.Cricketers.Remove(cricketer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CricketerExists(int id)
        {
            return _context.Cricketers.Any(e => e.Rank == id);
        }
    }
}
