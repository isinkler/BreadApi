using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Repositories.Contracts
{
    public interface IGenericBreadRepository<TDomain>        
        where TDomain : class
    {
        Task<TDomain> GetAsync(int id);

        Task<IEnumerable<TDomain>> GetAllAsync();

        Task<TDomain> CreateAsync(TDomain domainModel);

        Task<TDomain> UpdateAsync(TDomain domainModel);

        Task<bool> DeleteAsync(int id);
    }
}
