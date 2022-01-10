using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bed_Availability_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public DrinkController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Drink
        [HttpGet]
        public IActionResult GetAllDrinks()
        {
            var drink = _repository.Drink.GetAllDrinks(trackChanges: false);
            return Ok(drink);
        }


        // GET: api/Drink/1
        [HttpGet("{id}")]
        public IActionResult GetDrink(int id)
        {
            var drink = _repository.Drink.GetDrink(id, trackChanges: false);
            if (drink == null)
            {
                _logger.LogInfo($"drink with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(drink);
            }
        }
        // POST: api/Drink
        [HttpPost]
        public IActionResult CreateDrink([FromBody] Drink drink)
        {
            if (drink == null)
            {
                _logger.LogError("drink sent from client is null.");
                return BadRequest("drink object is null");
            }
            _repository.Drink.CreateDrink(drink);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Drink/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDrink(int id)
        {
            Drink drink = _repository.Drink.GetDrink(id, false);
            if (drink == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Drink.DeleteDrink(drink);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Drink/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Drink drink)
        {
            if (drink == null)
            {
                return BadRequest("category is null.");
            }
            Drink drinkToUpdate = _repository.Drink.GetDrink(id, false);
            if (drinkToUpdate == null)
            {
                return NotFound("The drink record couldn't be found.");
            }
            drink.Id = id;
            _repository.Drink.UpdateDrink(drink);
            _repository.Save();
            return Ok("Drink Updated");
        }
    }
}
