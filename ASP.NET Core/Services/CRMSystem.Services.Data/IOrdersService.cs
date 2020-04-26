using System.Threading.Tasks;

namespace CRMSystem.Services.Data
{
    public interface IOrdersService
    {
        //Task<int> CreateAsync(int dealId, int productId, int quantity);
        Task<int> CreateAsync<T>(T model);
    }
}
