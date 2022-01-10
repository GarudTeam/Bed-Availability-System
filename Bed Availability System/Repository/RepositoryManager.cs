using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IDrinkRepository _drinkRepository;
        private IFoodRepository _foodRepository;
        private IReservationRepository _ReservationRepository;
        private IRoomViewModelRepository _RoomViewModelRepository;
        private IServiceRepository _ServiceRepository;
        private IAccountRepository _AccountRepository;
        private IInvoiceViewModelRepository _invoiceViewModel;



        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDrinkRepository Drink
        {
            get
            {
                if (_drinkRepository == null)
                    _drinkRepository = new DrinkRepository(_repositoryContext);
                return _drinkRepository;
            }
        }


        public IFoodRepository Food
        {
            get
            {
                if (_foodRepository == null)
                    _foodRepository = new FoodRepository(_repositoryContext);
                return _foodRepository;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_ReservationRepository == null)
                    _ReservationRepository = new ReservationRepository(_repositoryContext);
                return _ReservationRepository;
            }
        }

        public IRoomViewModelRepository RoomViewModel
        {
            get
            {
                if (_RoomViewModelRepository == null)
                    _RoomViewModelRepository = new RoomViewModelRepository(_repositoryContext);
                return _RoomViewModelRepository;
            }
        }


        public IServiceRepository Service
        {
            get
            {
                if (_ServiceRepository == null)
                    _ServiceRepository = new ServiceRepository(_repositoryContext);
                return _ServiceRepository;
            }
        }

        public IAccountRepository User
        {
            get
            {
                if (_AccountRepository == null)
                    _AccountRepository = new AccountRepository(_repositoryContext);
                return _AccountRepository;
            }
        }

        public IInvoiceViewModelRepository InvoiceViewModel
        {
            get
            {
                if (_invoiceViewModel == null)
                    _invoiceViewModel = new InvoiceViewModelRepository(_repositoryContext);
                return _invoiceViewModel;
            }
        }







        public void Save() => _repositoryContext.SaveChanges();
    }
}
