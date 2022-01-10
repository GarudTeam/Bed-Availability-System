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
    public class InvoiceViewModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public InvoiceViewModelController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoice = _repository.InvoiceViewModel.GetAllInvoiceViewModels(trackChanges: false);
            return Ok(invoice);
        }


        // GET: api/Invoice/1
        [HttpGet("{id}")]
        public IActionResult GetInvoiceViewModel(int id)
        {
            var invoice = _repository.InvoiceViewModel.GetInvoiceViewModel(id, trackChanges: false);
            if (invoice == null)
            {
                _logger.LogInfo($"drink with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(invoice);
            }
        }
        // POST: api/Invoice
        [HttpPost]
        public IActionResult CreateInvoiceViewModel([FromBody] InvoiceViewModel invoice)
        {
            if (invoice == null)
            {
                _logger.LogError("drink sent from client is null.");
                return BadRequest("drink object is null");
            }
            _repository.InvoiceViewModel.CreateInvoiceViewModel(invoice);
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoiceViewModel(int id)
        {
            InvoiceViewModel invoice = _repository.InvoiceViewModel.GetInvoiceViewModel(id, false);
            if (invoice == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database.");
                return NotFound("The category record couldn't be found.");
            }
            _repository.InvoiceViewModel.DeleteInvoiceViewModel(invoice);
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
            return Ok("Invoice Updated");
        }
    }
}
