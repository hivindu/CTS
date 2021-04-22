using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using System.Net;
using CovidTracing.API.Repository.Interface;

namespace CovidTracing.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitizensController : ControllerBase
    {
        private readonly ICitizensRepository _repository;

        public CitizensController(ICitizensRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Citizens
        [ProducesResponseType(typeof(IEnumerable<CDC>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CDC>>> GetCitizen()
        {
            var CDC = await _repository.GetCitizen();

            return Ok(CDC);
        }

        // GET: api/Citizens/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CDC), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CDC>> GetCitizen(int id)
        {
            var cdc = await _repository.GetCitizen(id);

            if (cdc == null)
            {
                return NotFound();
            }

            return Ok(cdc);
        }

        // DELETE: api/Citizens/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CDC), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CDC>> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(typeof(Citizen), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ActiveCitizen([FromBody] int id)
        {
            return Ok(await _repository.ActiveCitizen(id));
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(typeof(Citizen), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeactivateCitizen([FromBody] int id)
        {
            return Ok(await _repository.DeactivateCitizen(id));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Citizen), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] Citizen citizen)
        {
            if (citizen.Id != citizen.Id)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(citizen));
        }

        // POST api/<CTSController>
        [HttpPost]
        public async Task<ActionResult<Citizen>> Create(Citizen citizen)
        {
            await _repository.Create(citizen);

            return CreatedAtAction("GetCitizen", new { id = citizen.Id }, citizen);
        }

       
    }
}
