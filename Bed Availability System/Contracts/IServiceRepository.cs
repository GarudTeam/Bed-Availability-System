using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
  public  interface IServiceRepository
    {
        public IEnumerable<Service> GetAllServices(bool trackChanges);

        public Service GetService(int ServiceId, bool trackChanges);
        void CreateService(Service Service);
        void DeleteService(Service Service);
        void UpdateService(Service Service);
    }
}
