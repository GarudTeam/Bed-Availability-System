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
    class InvoiceViewModelRepository : RepositoryBase<InvoiceViewModel>, IInvoiceViewModelRepository
    {
        public InvoiceViewModelRepository(RepositoryContext repositoryContext)
: base(repositoryContext)
        {
        }


        public void CreateInvoiceViewModel(InvoiceViewModel InvoiceViewModel)
        {
            Create(InvoiceViewModel);
        }

        public void DeleteInvoiceViewModel(InvoiceViewModel InvoiceViewModel)
        {
            Delete(InvoiceViewModel);
        }

        public IEnumerable<InvoiceViewModel> GetAllInvoiceViewModels(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public InvoiceViewModel GetInvoiceViewModel(int InvoiceViewModelId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(InvoiceViewModelId), trackChanges).SingleOrDefault();



        void IInvoiceViewModelRepository.UpdateInvoiceViewModel(InvoiceViewModel InvoiceViewModel)
        {
            Update(InvoiceViewModel);
        }
    }
}
