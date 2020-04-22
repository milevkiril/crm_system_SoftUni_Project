using System.Threading.Tasks;

namespace CRMSystem.Services.Data
{
    public interface IOrdersService
    {
        Task Create(int dealId, int productId, int quantity);
    }
}
