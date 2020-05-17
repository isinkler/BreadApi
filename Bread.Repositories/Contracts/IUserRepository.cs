using System.Threading.Tasks;

using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<BLL.User> GetAsync(int id);

        Task<BLL.User> GetByEmailAsync(string emailAddress);

        Task<BLL.User> CreateAsync(BLL.User user);
    }
}
