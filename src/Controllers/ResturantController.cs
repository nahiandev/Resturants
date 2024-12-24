using Microsoft.AspNetCore.Mvc;
using Restaurants.DataAccessor;
using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;
using Restaurants.Services.Interfaces;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _service;
        private readonly ResturantDbContext _context;

        public ResturantController(IResturantService service, ResturantDbContext context)
        {
            _service = service;
            _context = context;
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
        public IActionResult AddResturant([FromBody] AddResturantDTO add_resturant_dto)
        {
            var domain_resturant = Mapper(add_resturant_dto);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            


            _context.Resturants.Add(domain_resturant);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetResturantById), new { id = domain_resturant.Id }, domain_resturant);
        }

        private static Resturant Mapper(AddResturantDTO add_resturant_dto)
        {
            return new Resturant
            {
                Name = add_resturant_dto.Name,
                Description = add_resturant_dto.Description,
                Category = add_resturant_dto.Category,
                HasDelivery = add_resturant_dto.HasDelivery,
                PhoneNumber = add_resturant_dto.PhoneNumber,
                Email = add_resturant_dto.Email
            };
        }
    }
}
