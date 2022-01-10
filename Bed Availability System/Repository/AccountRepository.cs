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
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext)
 : base(repositoryContext)
        {
        }


        public void CreateAccount(Account Account)
        {
            Create(Account);
        }

        public void DeleteAccount(Account Account)
        {
            Delete(Account);
        }

        public IEnumerable<Account> GetAllAccounts(bool trackChanges) =>

            FindAll(trackChanges).OrderBy(d => d.Id).ToList();


        public Account GetAccount(int AccountId, bool trackChanges) =>

            FindByCondition(d => d.Id.Equals(AccountId), trackChanges).SingleOrDefault();



        void IAccountRepository.UpdateAccount(Account Account)
        {
            Update(Account);
        }
    }
}
