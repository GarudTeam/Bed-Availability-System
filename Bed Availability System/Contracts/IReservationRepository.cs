using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReservationRepository
    {
        public IEnumerable<Reservation> GetAllReservations(bool trackChanges);

        public Reservation GetReservation(int ReservationId, bool trackChanges);
        void CreateReservation(Reservation Reservation);
        void DeleteReservation(Reservation Reservation);
        void UpdateReservation(Reservation Reservation);
    }
}
