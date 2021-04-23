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
using System.Net;

namespace CovidTracing.API.Controllers
{
    [Route("api/v1/[controller]")]
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
        [ProducesResponseType(typeof(IEnumerable<PCR>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PCR>>> GetPCR()
        {
            var pcr = await _repository.GetRequests();

            return Ok(pcr);
        }

        [HttpGet("{id}",Name ="GetPCR")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PCR), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PCR>> GetRequestbyId(int id)
        {
            var phi = await _repository.GetRequestById(id);

            if (phi == null)
            {
                return NotFound();
            }

            return Ok(phi);
        }

        // GET: api/PCRs/5
        [HttpGet("[action]/{cid}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PCR), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PCR>> GetRequestbyCID(int cid)
        {
            var phi = await _repository.GetRequestbyCID(cid);

            if (phi == null)
            {
                return NotFound();
            }

            return Ok(phi);
        }

        
        [HttpPut]
        [ProducesResponseType(typeof(PCR), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutPCR([FromBody]PCR pCR)
        {
            return Ok(await _repository.Update(pCR));
        }

        // POST: api/PCRs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PCR>> PostPCR(PCR pCR)
        {
            await _repository.Create(pCR);

            return CreatedAtAction("GetPCR", new { id = pCR.Id }, pCR);
        }

        // DELETE: api/PCRs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PCR), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PCR>> DeletePCR(int id)
        {
            return Ok(await _repository.Delete(id));
        }

    }
}
