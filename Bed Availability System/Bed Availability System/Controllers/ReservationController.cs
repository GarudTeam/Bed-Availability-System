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
    public class ReservationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ReservationController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Reservation
        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var reservations = _repository.Reservation.GetAllReservations(trackChanges: false);
            return Ok(reservations);
        }


        // GET: api/Reservation/1
        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var Reservation = _repository.Reservation.GetReservation(id, trackChanges: false);
            if (Reservation == null)
            {
                _logger.LogInfo($"Reservation with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(Reservation);
            }
        }
        // POST: api/Reservation
        [HttpPost]
        public IActionResult CreateReservation([FromBody] Reservation Reservation)
        {
            if (Reservation == null)
            {
                _logger.LogError("Reservation sent from client is null.");
                return BadRequest("Reservation object is null");
            }
            _repository.Reservation.CreateReservation(Reservation);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            Reservation Reservation = _repository.Reservation.GetReservation(id, false);
            if (Reservation == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.Reservation.DeleteReservation(Reservation);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Reservation/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Reservation Reservation)
        {
            if (Reservation == null)
            {
                return BadRequest("category is null.");
            }
            Reservation ReservationToUpdate = _repository.Reservation.GetReservation(id, false);
            if (ReservationToUpdate == null)
            {
                return NotFound("The Reservation record couldn't be found.");
            }
            Reservation.Id = id;
            _repository.Reservation.UpdateReservation(Reservation);
            _repository.Save();
            return Ok("Reservation Updated");
        }
    }
}
