using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRoomViewModelRepository
    {
        public IEnumerable<RoomViewModel> GetAllRoomViewModels(bool trackChanges);

        public RoomViewModel GetRoomViewModel(int RoomId, bool trackChanges);
        void CreateRoomViewModel(RoomViewModel Room);
        void DeleteRoomViewModel(RoomViewModel Room);
        void UpdateRoomViewModel(RoomViewModel Room);
    }
}
