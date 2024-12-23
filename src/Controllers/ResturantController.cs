using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurants.DataAccessor;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly ResturantDbContext _context;

        public ResturantController(ResturantDbContext context)
        {
           
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            var resturants = await _context.Resturants.ToListAsync();
            if (resturants.Count is 0)
            {
                return NotFound();
            }
            return Ok(resturants);
        }


    }
}
