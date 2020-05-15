using AutoMapper;

using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Services.Contracts;

using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class UserService : BreadService, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(Authentication authentication)
        {
            BLL.User user = 
                await userRepository.GetByEmailAndPasswordAsync(authentication.EmailAddress, authentication.Password);

            return null;
        }
    }
}
