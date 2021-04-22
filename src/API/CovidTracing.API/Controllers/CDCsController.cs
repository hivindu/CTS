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
    public class CDCsController : ControllerBase
    {
        private readonly ICDCRepository _repository;

        public CDCsController(ICDCRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CTSController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CDC>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CDC>>> GetCDC()
        {
            var CDC = await _repository.GetCDC();

            return Ok(CDC);
        }

        // GET api/<CTSController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CDC), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CDC>> GetCDC(int id)
        {
            var cdc = await _repository.GetCDC(id);

            if (cdc == null)
            {
                return NotFound();
            }

            return Ok(cdc);
        }

        

       


        // POST api/<CTSController>
        [HttpPost]
        public async Task<ActionResult<CDC>> CreateCDC(CDC cdc)
        {
            await _repository.Create(cdc);

            return CreatedAtAction("GetCDC", new { id = cdc.Id }, cdc);
        }

        // PUT api/<CTSController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CDC), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] CDC cdc)
        {
            if (cdc.Id != cdc.Id)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(cdc));
        }

        // DELETE api/<CTSController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CDC), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CDC>> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
