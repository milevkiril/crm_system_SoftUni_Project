namespace CRMSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDealsService
    {
        Task<int> CreateAsync(string dealName, string userId);

        IEnumerable<T> GetAll<T>();
    }
}
