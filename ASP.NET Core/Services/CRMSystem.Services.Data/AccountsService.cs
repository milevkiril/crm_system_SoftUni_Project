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

        public T GetById<T>(int id)
        {
            var account = this.accountReposityory.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return account;
        }
<<<<<<< HEAD

        public T GetByName<T>(string name)
        {
            var account = this.accountReposityory.All()
                .Where(x => x.AccountName.Replace(" ", "-") == name.Replace(" ", "-"))
                .To<T>().FirstOrDefault();
            return account;
        }
=======
>>>>>>> 5c1d09cda30939a408f8dac636b462151659c0ea
    }
}
