using Bread.DataTransfer;

using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IUserService
    {
       Task<User> AuthenticateAsync(Authentication authentication);
    }
}
