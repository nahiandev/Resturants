using Microsoft.AspNetCore.Mvc;
using Restaurants.DataAccessor;
using Restaurants.Domains.Models;

namespace Resturants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ResturantDbContext _context;

        public DishesController(ResturantDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
           throw new NotImplementedException();
        }

        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Dish>> GetDishById(int id)
        {
            throw new NotImplementedException();
        }

        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDish(int id, Dish dish)
        {
            throw new NotImplementedException();
        }

        
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(Dish dish)
        {
            throw new NotImplementedException();
        }

       
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
