using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMSystem.Services.Data
{
    public interface IRolesSurvice
    {
        Task<string> CreateAsync(string name);

        IEnumerable<T> GetByCategoryId<T>();
    }
}
