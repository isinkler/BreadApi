using System.Threading.Tasks;

using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IUserRepository : IGenericBreadRepository<BLL.User>
    {        
        Task<BLL.User> GetByEmailAsync(string emailAddress);        
    }
}
