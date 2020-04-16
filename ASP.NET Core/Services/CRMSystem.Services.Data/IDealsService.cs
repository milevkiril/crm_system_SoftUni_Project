namespace CRMSystem.Services.Data
{
    using CRMSystem.Data.Models.Enumerators;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDealsService
    {
        Task<int> CreateAsync(string dealName, string userId, string description, Stage stage, int accountId);

        IEnumerable<T> GetByAccountId<T>(int accountId, int? take = null, int skip = 0);

        T GetById<T>(int id);
    }
}
