using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidTracing.API.Data;
using CovidTracing.API.Entities;

namespace CovidTracing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PHIsController : ControllerBase
    {
        private readonly CovidTracingAPIDBContext _context;

        public PHIsController(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/PHIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PHI>>> GetPHI()
        {
            return await _context.PHI.ToListAsync();
        }

        // GET: api/PHIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PHI>> GetPHI(int id)
        {
            var pHI = await _context.PHI.FindAsync(id);

            if (pHI == null)
            {
                return NotFound();
            }

            return pHI;
        }

        // PUT: api/PHIs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPHI(int id, PHI pHI)
        {
            if (id != pHI.Id)
            {
                return BadRequest();
            }

            _context.Entry(pHI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PHIExists(id))
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

        // POST: api/PHIs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PHI>> PostPHI(PHI pHI)
        {
            _context.PHI.Add(pHI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPHI", new { id = pHI.Id }, pHI);
        }

        // DELETE: api/PHIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PHI>> DeletePHI(int id)
        {
            var pHI = await _context.PHI.FindAsync(id);
            if (pHI == null)
            {
                return NotFound();
            }

            _context.PHI.Remove(pHI);
            await _context.SaveChangesAsync();

            return pHI;
        }

        private bool PHIExists(int id)
        {
            return _context.PHI.Any(e => e.Id == id);
        }
    }
}
