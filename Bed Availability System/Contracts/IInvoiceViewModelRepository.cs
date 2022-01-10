using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IInvoiceViewModelRepository
    {
        public IEnumerable<InvoiceViewModel> GetAllInvoiceViewModels(bool trackChanges);

        public InvoiceViewModel GetInvoiceViewModel(int InvoiceViewModelId, bool trackChanges);
        void CreateInvoiceViewModel(InvoiceViewModel InvoiceViewModel);
        void DeleteInvoiceViewModel(InvoiceViewModel InvoiceViewModel);
        void UpdateInvoiceViewModel(InvoiceViewModel InvoiceViewModel);
    }
}
