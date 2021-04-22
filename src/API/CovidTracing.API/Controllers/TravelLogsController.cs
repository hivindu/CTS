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
    public class TravelLogsController : ControllerBase
    {
        private readonly ITravelLogRepository _repository;

        public TravelLogsController(ITravelLogRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TravelLogs
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TravelLog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TravelLog>>> GetTravelLog()
        {
            var tr =  await _repository.GetTravelLog();

            return Ok(tr);
        }

        // GET: api/TravelLogs/5
        [HttpGet("{id}", Name = "GetLog")]
        [ProducesResponseType(typeof(IEnumerable<TravelLog>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TravelLog>>> GetTravelLog(int id)
        {
            var travelLog = await _repository.GetTravelLogbyId(id);

            if (travelLog == null)
            {
                return NotFound();
            }

            return Ok(travelLog);
        }

        [HttpGet("[action]/{Latitude}/{longtitude}")]
        [ProducesResponseType(typeof(IEnumerable<Citizen>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetCitizensbyTravelLocations(float Latitude,float longtitude)
        {
            var travelLog = await _repository.GetCitizensbyTravelLocations(longtitude,longtitude);

            if (travelLog == null)
            {
                return NotFound();
            }

            return Ok(travelLog);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TravelLog), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutTravelLog([FromBody] TravelLog travelLog)
        {
            return Ok(await _repository.UpdateTravelLog(travelLog));
        }

        
        [HttpPost]
        public async Task<ActionResult<TravelLog>> PostTravelLog(TravelLog travelLog)
        {
            await _repository.AddTravelLog(travelLog);

            return CreatedAtAction("GetRooms", new { id = travelLog.Id }, travelLog);
        }

        // DELETE: api/TravelLogs/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TravelLog), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TravelLog>> DeleteTravelLog(int id)
        {
            return Ok(await _repository.DeleteTravelLog(id));
        }

    }
}
