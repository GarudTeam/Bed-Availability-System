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
    public class AccountController : ControllerBase
    {
        private readonly IRepositoryManager _repository; //Used Repository Manager Performing All Repository
        private readonly ILoggerManager _logger; //Used For Logger Msg

        public AccountController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository; 
            _logger = logger;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var Account = _repository.User.GetAllAccounts(trackChanges: false); //Get all Account Data
            return Ok(Account);
        }


        // GET: api/Account/1
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var Account = _repository.User.GetAccount(id, trackChanges: false); //Account By Id
            if (Account == null)
            {
                _logger.LogInfo($"Account with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(Account);
            }
        }
        // POST: api/Account
        [HttpPost]
        public IActionResult CreateAccount([FromBody] Account Account)
        {
            if (Account == null)
            {
                _logger.LogError("Account sent from client is null."); //Error Msg Show Using Logger Manager
                return BadRequest("Account object is null");
            }
            _repository.User.CreateAccount(Account); //Create New Account
            _repository.Save();
            return Ok("Successully Added");
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            Account Account = _repository.User.GetAccount(id, false);
            if (Account == null)
            {
                _logger.LogInfo($"Category with id: {id} doesn't exist in the database."); //Info Msg Show Using Logger Manager
                return NotFound("The category record couldn't be found.");
            }
            _repository.User.DeleteAccount(Account);
            _repository.Save();
            return Ok("Successully Deleted");
        }

        // PUT: api/Account/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Account Account)
        {
            if (Account == null)
            {
                return BadRequest("category is null.");
            }
            Account AccountToUpdate = _repository.User.GetAccount(id, false);
            if (AccountToUpdate == null)
            {
                return NotFound("The Account record couldn't be found.");
            }
          
            _repository.User.UpdateAccount(Account);
            _repository.Save();
            return Ok("Successully Updated");
        }
    }
}
