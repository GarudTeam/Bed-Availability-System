using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public  class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {

        public ReservationRepository(RepositoryContext repositoryContext)
: base(repositoryContext)
        {
        }


        public void CreateReservation(Reservation Reservation)
        {
            Create(Reservation);
        }

        public void DeleteReservation(Reservation Reservation)
        {
            Delete(Reservation);
        }

        public IEnumerable<Reservation> GetAllReservations(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public Reservation GetReservation(int ReservationId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(ReservationId), trackChanges).SingleOrDefault();



        void IReservationRepository.UpdateReservation(Reservation Reservation)
        {
            Update(Reservation);
        }


    }
}
