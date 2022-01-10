using Amazon.IdentityManagement.Model;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class FoodController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public FoodController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Food
      
        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var Food = _repository.Food.GetAllFoods(trackChanges: false);
            return Ok(Food);
        }


        // GET: api/Food/1
        [HttpGet("{id}")]
        public IActionResult GetFood(int id)
        {
            var Food = _repository.Food.GetFood(id, trackChanges: false);
            if (Food == null)
            {
                _logger.LogInfo($"Food with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(Food);
            }
        }
        // POST: api/Food
        [HttpPost]
        public IActionResult CreateFood([FromBody] Food food)
        {
            if (food == null)
            {
                _logger.LogError("Food sent from client is null.");
                return BadRequest("Food object is null");
            }
            _repository.Food.CreateFood(food);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFood(int id)
        {
            Food Food = _repository.Food.GetFood(id, false);
            if (Food == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Food.DeleteFood(Food);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Food/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Food Food)
        {
            if (Food == null)
            {
                return BadRequest("category is null.");
            }
            Food FoodToUpdate = _repository.Food.GetFood(id, false);
            if (FoodToUpdate == null)
            {
                return NotFound("The Food record couldn't be found.");
            }
            Food.Id = id;
            _repository.Food.UpdateFood(Food);
            _repository.Save();
            return Ok("Food Updated");
        }

    }
}
