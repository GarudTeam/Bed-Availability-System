using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAccountRepository
    {
        public IEnumerable<Account> GetAllAccounts(bool trackChanges);

        public Account GetAccount(int id, bool trackChanges);
        void CreateAccount(Account Account);
        void DeleteAccount(Account Account);
        void UpdateAccount(Account Account);
    }
}
