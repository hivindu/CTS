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
    public class TravelLogsController : ControllerBase
    {
        private readonly CovidTracingAPIDBContext _context;

        public TravelLogsController(CovidTracingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/TravelLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelLog>>> GetTravelLog()
        {
            return await _context.TravelLog.ToListAsync();
        }

        // GET: api/TravelLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelLog>> GetTravelLog(int id)
        {
            var travelLog = await _context.TravelLog.FindAsync(id);

            if (travelLog == null)
            {
                return NotFound();
            }

            return travelLog;
        }

        // PUT: api/TravelLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelLog(int id, TravelLog travelLog)
        {
            if (id != travelLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelLogExists(id))
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

        // POST: api/TravelLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TravelLog>> PostTravelLog(TravelLog travelLog)
        {
            _context.TravelLog.Add(travelLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelLog", new { id = travelLog.Id }, travelLog);
        }

        // DELETE: api/TravelLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TravelLog>> DeleteTravelLog(int id)
        {
            var travelLog = await _context.TravelLog.FindAsync(id);
            if (travelLog == null)
            {
                return NotFound();
            }

            _context.TravelLog.Remove(travelLog);
            await _context.SaveChangesAsync();

            return travelLog;
        }

        private bool TravelLogExists(int id)
        {
            return _context.TravelLog.Any(e => e.Id == id);
        }
    }
}
