using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface IRepositoryManager
    {
        IDrinkRepository Drink { get; }
        IFoodRepository Food { get; }

        IReservationRepository Reservation { get; }

        IRoomViewModelRepository RoomViewModel { get; }

        IServiceRepository Service { get; }

        IAccountRepository User { get; }

        IInvoiceViewModelRepository InvoiceViewModel { get; }








        void Save();
    }
}
