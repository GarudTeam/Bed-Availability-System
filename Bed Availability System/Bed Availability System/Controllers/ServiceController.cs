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
    public class ServiceController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ServiceController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Service
        [HttpGet]
        public IActionResult GetAllServices()
        {
            var Service = _repository.Service.GetAllServices(trackChanges: false);
            return Ok(Service);
        }


        // GET: api/Service/1
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var Service = _repository.Service.GetService(id, trackChanges: false);
            if (Service == null)
            {
                _logger.LogInfo($"Service with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(Service);
            }
        }
        // POST: api/Service
        [HttpPost]
        public IActionResult CreateService([FromBody] Service Service)
        {
            if (Service == null)
            {
                _logger.LogError("Service sent from client is null.");
                return BadRequest("Service object is null");
            }
            _repository.Service.CreateService(Service);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            Service Service = _repository.Service.GetService(id, false);
            if (Service == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Service.DeleteService(Service);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Service/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Service Service)
        {
            if (Service == null)
            {
                return BadRequest("category is null.");
            }
            Service ServiceToUpdate = _repository.Service.GetService(id, false);
            if (ServiceToUpdate == null)
            {
                return NotFound("The Service record couldn't be found.");
            }
            Service.Id = id;
            _repository.Service.UpdateService(Service);
            _repository.Save();
            return Ok("Service Updated");
        }
    }
}
