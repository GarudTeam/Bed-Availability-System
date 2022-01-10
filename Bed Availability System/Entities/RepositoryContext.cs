using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class RepositoryContext : IdentityDbContext<Account, AppRole, int>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
           : base(options)
        {

        }



        public DbSet<RoomViewModel> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<InvoiceViewModel> Invoices { get; set; }

    }
}
