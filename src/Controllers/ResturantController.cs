using Microsoft.AspNetCore.Mvc;
using Restaurants.Models.DTOs;
using Restaurants.Services.Interfaces;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            if (resturants.Count is 0) return NotFound();

            return Ok(resturants);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var resturant = await _service.GetMappedResturantByIdAsync(id);

            if (resturant is null) return NotFound();
            
            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] AddResturantDTO add_resturant_dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
        
            try
            {
                var id = await _service.AddMappedResturantAsync(add_resturant_dto);

                return CreatedAtAction(nameof(GetResturantById), new { id }, add_resturant_dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } 
    }
}
