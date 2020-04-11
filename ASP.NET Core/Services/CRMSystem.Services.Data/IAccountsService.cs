namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountsService
    {
        Task<int> CreateAsync(string accountName, string userId, AccountType typeAccount);

        IEnumerable<T> GetAll<T>();
    }
}
