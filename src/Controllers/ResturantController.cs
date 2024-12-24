using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Restaurants.Models.Domains;
using Restaurants.Models.DTOs;
using Restaurants.Repository.Interfaces;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IResturantRepository _repository;

        public ResturantController(IResturantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            var resturants = await _repository.GetResturantsAsync();
            if (resturants.Count is 0)
            {
                return NotFound();
            }

            var mapped_resturants = resturants.Select(r => Mapper(r));

            return Ok(mapped_resturants);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var resturant = await _repository.GetResturantByIdAsync(id);
            if (resturant is null)
            {
                return NotFound();
            }

            var mapped_resturant = Mapper(resturant);
            return Ok(mapped_resturant);
        }

        private static ResturantDTO Mapper(Resturant source)
        {
            return new()
            {
                Name = source.Name,
                Description = source.Description,
                Category = source.Category,
                HasDelivery = source.HasDelivery
            };
        }
    }
}
