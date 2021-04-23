using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;

namespace CovidTracing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCRsController : ControllerBase
    {
        private readonly IPCRRepository _repository;

        public PCRsController(IPCRRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PCRs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCR>>> GetPCR()
        {
            return await _repository.GetRequests();
        }

        // GET: api/PCRs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PCR>> GetPCR(int id)
        {
            var pCR = await _context.PCR.FindAsync(id);

            if (pCR == null)
            {
                return NotFound();
            }

            return pCR;
        }

        // PUT: api/PCRs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPCR(int id, PCR pCR)
        {
            if (id != pCR.Id)
            {
                return BadRequest();
            }

            _context.Entry(pCR).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCRExists(id))
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

        // POST: api/PCRs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PCR>> PostPCR(PCR pCR)
        {
            _context.PCR.Add(pCR);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPCR", new { id = pCR.Id }, pCR);
        }

        // DELETE: api/PCRs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PCR>> DeletePCR(int id)
        {
            var pCR = await _context.PCR.FindAsync(id);
            if (pCR == null)
            {
                return NotFound();
            }

            _context.PCR.Remove(pCR);
            await _context.SaveChangesAsync();

            return pCR;
        }

        private bool PCRExists(int id)
        {
            return _context.PCR.Any(e => e.Id == id);
        }
    }
}
