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
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(RepositoryContext repositoryContext)
: base(repositoryContext)
        {
        }


        public void CreateService(Service Service)
        {
            Create(Service);
        }

        public void DeleteService(Service Service)
        {
            Delete(Service);
        }

        public IEnumerable<Service> GetAllServices(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public Service GetService(int ServiceId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(ServiceId), trackChanges).SingleOrDefault();



        void IServiceRepository.UpdateService(Service Service)
        {
            Update(Service);
        }
    }
}
