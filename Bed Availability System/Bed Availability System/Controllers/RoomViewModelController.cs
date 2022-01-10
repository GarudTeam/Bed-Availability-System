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
    public class RoomViewModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public RoomViewModelController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Room
        [HttpGet]
        public IActionResult GetAllRoomViewModels()
        {
            var RoomViewModel = _repository.RoomViewModel.GetAllRoomViewModels(trackChanges: false);
            return Ok(RoomViewModel);
        }


        // GET: api/Room/1
        [HttpGet("{id}")]
        public IActionResult GetRoomViewModel(int id)
        {
            var RoomViewModel = _repository.RoomViewModel.GetRoomViewModel(id, trackChanges: false);
            if (RoomViewModel == null)
            {
                _logger.LogInfo($"RoomViewModel with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(RoomViewModel);
            }
        }
        // POST: api/Room
        [HttpPost]
        public IActionResult CreateRoomViewModel([FromBody] RoomViewModel RoomViewModel)
        {
            if (RoomViewModel == null)
            {
                _logger.LogError("RoomViewModel sent from client is null.");
                return BadRequest("RoomViewModel object is null");
            }
            _repository.RoomViewModel.CreateRoomViewModel(RoomViewModel);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRoomViewModel(int id)
        {
            RoomViewModel RoomViewModel = _repository.RoomViewModel.GetRoomViewModel(id, false);
            if (RoomViewModel == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.RoomViewModel.DeleteRoomViewModel(RoomViewModel);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Room/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoomViewModel RoomViewModel)
        {
            if (RoomViewModel == null)
            {
                return BadRequest("category is null.");
            }
            RoomViewModel RoomViewModelToUpdate = _repository.RoomViewModel.GetRoomViewModel(id, false);
            if (RoomViewModelToUpdate == null)
            {
                return NotFound("The RoomViewModel record couldn't be found.");
            }
            RoomViewModel.Id = id;
            _repository.RoomViewModel.UpdateRoomViewModel(RoomViewModel);
            _repository.Save();
            return Ok("Room Updated");
        }
    }
}
