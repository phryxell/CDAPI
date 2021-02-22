using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CDAPI.Data;
using CDAPI.Models;

namespace CDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly CDContext _context;

        public CDsController(CDContext context)
        {
            _context = context;
        }

        // GET: api/CDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CD>>> Getcds()
        {
            return await _context.cds.ToListAsync();
        }

        // GET: api/CDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CD>> GetCD(int id)
        {
            var cD = await _context.cds.FindAsync(id);

            if (cD == null)
            {
                return NotFound();
            }

            return cD;
        }

        // PUT: api/CDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCD(int id, CD cD)
        {
            if (id != cD.ID)
            {
                return BadRequest();
            }

            _context.Entry(cD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDExists(id))
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

        // POST: api/CDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CD>> PostCD(CD cD)
        {
            _context.cds.Add(cD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCD", new { id = cD.ID }, cD);
        }

        // DELETE: api/CDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCD(int id)
        {
            var cD = await _context.cds.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }

            _context.cds.Remove(cD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CDExists(int id)
        {
            return _context.cds.Any(e => e.ID == id);
        }
    }
}
