using Bread.DataTransfer;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.Services.Contracts
{
    public interface IUserService
    {
        Task<string> LoginAsync(Authentication authentication);

        Task<DTO.User> RegisterAsync(DTO.User user);        
    }
}
