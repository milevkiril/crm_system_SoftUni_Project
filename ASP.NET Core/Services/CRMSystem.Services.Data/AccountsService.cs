namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using CRMSystem.Services.Mapping;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;

    public class AccountsService : IAccountsService
    {
        private readonly IDeletableEntityRepository<Account> accountReposityory;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsService(
            IDeletableEntityRepository<Account> accountReposityory,
            UserManager<ApplicationUser> userManager)
        {
            this.accountReposityory = accountReposityory;
            this.userManager = userManager;
        }

        public async Task<int> CreateAsync(string accountName, string userId, AccountType typeAccount)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var userName = user.UserName;

            var account = new Account
            {
                AccountName = accountName,
                UserId = userId,
                TypeAccount = typeAccount,
                AccountOwner = userName,
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
