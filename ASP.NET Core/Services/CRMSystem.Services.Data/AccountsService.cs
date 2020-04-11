using CRMSystem.Data.Common.Repositories;
using CRMSystem.Data.Models;
using CRMSystem.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Services.Data
{
    public class AccountsService : IAccountsService
    {
        private readonly IDeletableEntityRepository<Account> accountReposityory;

        public AccountsService(IDeletableEntityRepository<Account> accountReposityory)
        {
            this.accountReposityory = accountReposityory;
        }

        public async Task<int> CreateAsync(string accountName, string userId, AccountType typeAccount)
        {
            var account = new Account
            {
                AccountName = accountName,
                UserId = userId,
                TypeAccount = typeAccount,
            };

            await this.accountReposityory.AddAsync(account);
            await this.accountReposityory.SaveChangesAsync();
            return account.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Account> accounts = this.accountReposityory
                .All()
                .OrderByDescending(x => x.CreatedOn);

            return accounts.To<T>().ToList();
        }
    }
}
