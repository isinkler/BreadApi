
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<BLL.User> GetByEmailAndPasswordAsync(string emailAddress, string password);
    }
}
