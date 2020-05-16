using AutoMapper;

using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Security.Contracts;
using Bread.Services.Contracts;

using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class UserService : BreadService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;

        public UserService(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IMapper mapper
        ) 
            : base(mapper)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public async Task<DTO.User> LoginAsync(Authentication authentication)
        {
            BLL.User bllUser = await userRepository.GetByEmailAsync(authentication.EmailAddress);

            var (Verified, NeedsUpgrade) = passwordHasher.Check(bllUser.Password, authentication.Password);

            DTO.User result = Mapper.Map<DTO.User>(bllUser);

            return result;
        }

        public async Task<DTO.User> RegisterAsync(DTO.User user)
        {
            BLL.User bllUser = Mapper.Map<BLL.User>(user);

            string hash = passwordHasher.Hash(bllUser.Password);
            bllUser.Password = hash;

            bllUser = await userRepository.CreateAsync(bllUser);

            DTO.User result = Mapper.Map<DTO.User>(bllUser);

            return result;
        }
    }
}
