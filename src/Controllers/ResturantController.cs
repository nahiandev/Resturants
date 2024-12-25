using Microsoft.AspNetCore.Mvc;
using Restaurants.Models.DTOs;
using Restaurants.Services.Interfaces;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // ModelState related errors are handled and exposed to consumer here
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _service;
    
        public ResturantController(IResturantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            var resturants = await _service.GetMappedResturantsAsync();

            if (resturants.Count is 0) return NotFound("OOPS! This place is little empty.");

            return Ok(resturants);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var resturant = await _service.GetMappedResturantByIdAsync(id);

            if (resturant is null) return NotFound($"No Resturant found associated with Id: {id}");

            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] AddResturantDTO add_resturant_dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var (id, saved_resturant, exists) = await _service.AddMappedResturantAsync(add_resturant_dto);

            if (saved_resturant is null) return BadRequest("Recored not saved!");

            if (exists) return Conflict("Duplicate email, use a unique one!");

            return CreatedAtAction(nameof(GetResturantById), new { id }, saved_resturant);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
            var (success, name) = await _service.DeleteMappedResturantAsync(id);

            if (!success) return NotFound($"No Resturant found associated with Id: {id}");

            return Ok($"Resturant Name: {name} associated with Id: {id} was deleted.");
        }
    }
}
