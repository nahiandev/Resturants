using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Actions.Coomands.AddResturant;
using Restaurants.Actions.Queries.GetResturantById;
using Restaurants.Actions.Queries.GetResturants;
using Restaurants.Services.Interfaces;

namespace Restaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // ModelState related errors are handled and exposed to consumer here
    public class ResturantController : ControllerBase
    {
        private readonly IResturantService _service;
        private readonly IMediator _mediator;

        public ResturantController(IResturantService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetResturants()
        {
            var resturants = await _mediator.Send(new GetResturantsQuery());

            if (!resturants.Any()) return NotFound("OOPS! This place is little empty.");

            return Ok(resturants);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var resturant = await _mediator.Send(new GetResturantByIdQuery { Id = id });

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
            var (success, name) = await _service.DeleteMappedResturantAsync(id);

            if (!success) return NotFound($"No Resturant found associated with Id: {id}");

            return Ok($"Resturant Name: {name} associated with Id: {id} was deleted.");
        }
    }
}