using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;
using Restaurants.Models.Domains;
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
            return Ok(resturants);
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
            return Ok(resturant);
        }
    }
}
