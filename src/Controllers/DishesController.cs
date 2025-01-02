using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Restaurants.DomainMapper;
using Restaurants.Domains.Models;
using Resturants.Actions.Commands.AddDish;
using Resturants.Domains.DTOs;
using Resturants.Repository.Interfaces;

namespace Resturants.Controllers
{
    [Route("endpoints/resturants/{resturant_id}/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        
        private readonly IDishesRepository _repository;

        public DishesController(IDishesRepository repository)
        {
          
            this._repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> AddDish([FromRoute] int resturant_id, AddDishDTO dish_entry)
        {
            var domain_dish = DataMapper.Instance.Map(dish_entry);
            
            var saved = await _repository.AddDishAsync(domain_dish, CancellationToken.None);

            

            return Ok(saved);
        }

       

    }
}
