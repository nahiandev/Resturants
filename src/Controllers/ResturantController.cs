using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Actions.Commands.AddResturant;
using Restaurants.Actions.Commands.DeleteResturant;
using Restaurants.Actions.Commands.UpdateResturant;
using Restaurants.Actions.Queries.GetResturantById;
using Restaurants.Actions.Queries.GetResturants;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResturantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            var query = new GetResturantsQuery();
            
            var resturants = await _mediator.Send(query);
            
            if (!resturants.Any()) return NotFound("OOPS! This place is little empty.");
            
            return Ok(resturants);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var query = new GetResturantByIdQuery(id);

            var resturant = await _mediator.Send(query);

            if (resturant is null) return NotFound($"No Resturant found associated with Id: {id}");

            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] AddResturantCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _mediator.Send(command);

            if (id is -1) return BadRequest();

            return CreatedAtAction(nameof(GetResturantById), new { id }, command);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteResturant([FromRoute] int id)
        {
            var command = new DeleteResturantCommand(id);

            var success = await _mediator.Send(command);

            if (!success) return BadRequest($"No Resturant found associated with Id: {id}");

            return Ok($"Resturant associated with Id: {id} was deleted.");
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateResturant([FromRoute] int id, [FromBody] UpdateResturantCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch.");
            
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var result = await _mediator.Send(command);

            if (!result) return Conflict("Already in record.");
            
            return Ok();
        }
    }
}