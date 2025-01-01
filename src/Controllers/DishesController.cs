using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Domains.Models;
using Resturants.Actions.Commands.AddDish;

namespace Resturants.Controllers
{
    [Route("endpoints/resturants/{resturant_id}/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DishesController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> UpdateDish()
        {
            throw new NotImplementedException();
        }

        
        [HttpPost]
        public async Task<ActionResult<Dish>> AddDish([FromRoute] int resturant_id, AddDishCommand command)
        {
            await _mediator.Send(command);

            return Created();
        }

       
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
