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
    public class ShopsController : ControllerBase
    {
        private readonly IShopRepository _repository;

        public ShopsController(IShopRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Shops
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Shop>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop()
        {
            var tr = await _repository.GetShops();

            return Ok(tr);
        }

        // GET: api/Shops/5
        [HttpGet("{id}", Name ="GetShop")]
        [ProducesResponseType(typeof(IEnumerable<Shop>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await _repository.GetShop(id);

            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        [HttpGet("[action/]{BR}")]
        [ProducesResponseType(typeof(IEnumerable<Shop>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shop>> GetShopByBR(string BR)
        {
            var shop = await _repository.GetShopByBR(BR);

            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Shop), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PutShop([FromBody] Shop shop)
        {
            return Ok(await _repository.Update(shop));
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(typeof(Shop), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveShop(int id)
        {
            return Ok(await _repository.ApproveShop(id));
        }

        [HttpPut("[action]/{id}")]
        [ProducesResponseType(typeof(Shop), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RejectShop(int id)
        {
            return Ok(await _repository.RejectShop(id));
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(Shop shop)
        {
            await _repository.Create(shop);

            return CreatedAtAction("GetRooms", new { id = shop.Id }, shop);
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Shop), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Shop>> DeleteShop(int id)
        {
            return Ok(await _repository.Delete(id));
        }

    }
}
