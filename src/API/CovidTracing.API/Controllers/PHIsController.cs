using CovidTracing.API.Data;
using CovidTracing.API.Entities;
using CovidTracing.API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CovidTracing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PHIsController : ControllerBase
    {
        private readonly IPHIRepository _repository;

        public PHIsController(IPHIRepository repository)
        {
            _repository = repository;
        }

        // GET: api/PHIs
        [ProducesResponseType(typeof(IEnumerable<PHI>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PHI>>> GetPHI()
        {
            var PHI = await _repository.GetPHI();

            return Ok(PHI);
        }

        // GET: api/PHIs/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PHI), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PHI>> GetPHI(int id)
        {
            var phi = await _repository.GetPHI(id);

            if (phi == null)
            {
                return NotFound();
            }

            return Ok(phi);
        }

        [HttpPost]
        public async Task<ActionResult<CDC>> Create(PHI phi)
        {
            await _repository.Create(phi);

            return CreatedAtAction("GetPHI", new { id = phi.Id }, phi);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PHI), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] PHI phi)
        {
            if (phi.Id != phi.Id)
            {
                return BadRequest();
            }

            return Ok(await _repository.Update(phi));
        }

        // DELETE: api/PHIs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PHI), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PHI>> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }

      //  [HttpGet("[action]/{latitude, longtitude}")]
       // [ProducesResponseType(typeof(IEnumerable<PHI>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<PHI>> GetTravelLogByPHI(double longtitude, double latitude)
       // {
         //   var phi = await _repository.GetTravelLogByPHI(longtitude, latitude);

 //           if (phi == null)
   //         {
     //           return NotFound();
       //     }

        //    return Ok(phi);
       // }

       // [HttpPut("{id}")]
       // [ProducesResponseType(typeof(Citizen), (int)HttpStatusCode.OK)]
       //public async Task<IActionResult> UpdateCitizen([FromBody] Citizen citizen)
        //{
         //   if (citizen.Id != citizen.Id)
           // {
             //   return BadRequest();
            //}

            //return Ok(await _repository.UpdateCitizen(citizen));
       // }
    }
}
