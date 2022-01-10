using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bed_Availability_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<Account> UserMng { get; set; }
        private SignInManager<Account> SignMng { get; set; }
        private RepositoryContext _context { get; set; }
        public AuthenticationController(RepositoryContext applicationDbContext,
            UserManager<Account> UserMng, SignInManager<Account> SignMng)
        {
            this.UserMng = UserMng;
            this.SignMng = SignMng;
            this._context = applicationDbContext;
        }

        


        // GET: Authentication/DisplayUserProfile/
        [HttpGet]
        public async Task<IActionResult> DisplayUserProfile()
        {
            var Account = await _context.Users.FirstOrDefaultAsync(m => m.Id == (UserMng.GetUserAsync(HttpContext.User).Result).Id);
            if (Account == null)
            {
                return NotFound();
            }

            return Ok(Account);
        }



        [HttpPost]
        
   

        public async Task<IActionResult> CreateInvoiceById(int Id)
        {
            var Account = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == (UserMng.GetUserAsync(HttpContext.User).Result).Id);
            var userRole = _context.UserRoles.Where(ur => ur.UserId == Account.Id);
            var role = _context.Roles.Where(r => r.Id == userRole.ToList()[0].RoleId);
            if (role.ToList()[0].Name == "Customer")
                Id = Account.Id;
            var invoice = new InvoiceViewModel();
            var Customer = await UserMng
                .FindByIdAsync(Id.ToString());
            var services = await _context.Set<Service>()
                .Include(s => s.food)
                .Include(s => s.drink)
                .Include(s => s.Customer).Where(s => s.Customer.Id == Customer.Id)
                .ToListAsync();
            var rooms = await _context.Set<Reservation>()
                .Include(r => r.Customer)
                .Include(r => r.Room).Where(r => r.Customer.Id == Customer.Id)
                .ToListAsync();
            int cost = 0;
            for (int i = 0; i < services.Count; i++)
            {
                cost += services[i].Cost;
            }
            invoice.Customer = Customer;
            invoice.Services = services;
            invoice.Rooms = rooms;
            invoice.Cost = cost;

            return Ok(invoice);
        }


    }
}
