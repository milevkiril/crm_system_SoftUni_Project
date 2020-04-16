namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Common.Repositories;
    using CRMSystem.Data.Models;
    using CRMSystem.Data.Models.Enumerators;
    using CRMSystem.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DealsService : IDealsService
    {
        private readonly IDeletableEntityRepository<Deal> dealRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Account> accountRepository;

        public DealsService(
            IDeletableEntityRepository<Deal> dealRepository,
            UserManager<ApplicationUser> userManager,
            IDeletableEntityRepository<Account> accountRepository)
        {
            this.dealRepository = dealRepository;
            this.userManager = userManager;
            this.accountRepository = accountRepository;
        }

        public async Task<int> CreateAsync(string dealName, string userId, string description, Stage stage, int accountId)
        {
            var user = await this.userManager.FindByIdAsync(userId);
            var userName = user.UserName;

            var account = this.accountRepository
                .All()
                .Where(x => x.Id == accountId)
                .FirstOrDefault();
            var accountName = account.AccountName;

            var deal = new Deal
            {
                Name = dealName,
                UserId = userId,
                DealOwner = userName,
                AccountId = accountId,
                AccountName = accountName,
            };

            await this.dealRepository.AddAsync(deal);
            await this.dealRepository.SaveChangesAsync();
            return deal.Id;
        }


        public IEnumerable<T> GetByAccountId<T>(int accountId, int? take = null, int skip = 0)
        {
            var query = this.dealRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.AccountId == accountId).Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var deal = this.dealRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return deal;
        }
    }
}
