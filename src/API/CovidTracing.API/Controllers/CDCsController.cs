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
    public class CDCsController : ControllerBase
    {
        private readonly CovidTracingAPIDBContext _context;

        public CDCsController(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/CDCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CDC>>> GetCDC()
        {
            return await _context.CDC.ToListAsync();
        }

        // GET: api/CDCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CDC>> GetCDC(int id)
        {
            var cDC = await _context.CDC.FindAsync(id);

            if (cDC == null)
            {
                return NotFound();
            }

            return cDC;
        }

        // PUT: api/CDCs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCDC(int id, CDC cDC)
        {
            if (id != cDC.Id)
            {
                return BadRequest();
            }

            _context.Entry(cDC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDCExists(id))
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

        // POST: api/CDCs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CDC>> PostCDC(CDC cDC)
        {
            _context.CDC.Add(cDC);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCDC", new { id = cDC.Id }, cDC);
        }

        // DELETE: api/CDCs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CDC>> DeleteCDC(int id)
        {
            var cDC = await _context.CDC.FindAsync(id);
            if (cDC == null)
            {
                return NotFound();
            }

            _context.CDC.Remove(cDC);
            await _context.SaveChangesAsync();

            return cDC;
        }

        private bool CDCExists(int id)
        {
            return _context.CDC.Any(e => e.Id == id);
        }
    }
}
