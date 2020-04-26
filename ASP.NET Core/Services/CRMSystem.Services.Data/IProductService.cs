namespace CRMSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<int> CreateAsync(string productName, string description, string price, string userId);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        Task<decimal> GetProductPriceByIdAsync(int id);
    }
}
