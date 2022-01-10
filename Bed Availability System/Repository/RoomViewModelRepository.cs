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
    class RoomViewModelRepository : RepositoryBase<RoomViewModel>, IRoomViewModelRepository
    {
        public RoomViewModelRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
        {
        }


        public void CreateRoomViewModel(RoomViewModel RoomViewModel)
        {
            Create(RoomViewModel);
        }

        public void DeleteRoomViewModel(RoomViewModel RoomViewModel)
        {
            Delete(RoomViewModel);
        }

        public IEnumerable<RoomViewModel> GetAllRoomViewModels(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();

      

        public RoomViewModel GetRoomViewModel(int RoomViewModelId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(RoomViewModelId), trackChanges).SingleOrDefault();



        void IRoomViewModelRepository.UpdateRoomViewModel(RoomViewModel RoomViewModel)
        {
            Update(RoomViewModel);
        }
    }
}
