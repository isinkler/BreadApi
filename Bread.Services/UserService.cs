using AutoMapper;

using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Security.Contracts;
using Bread.Services.Contracts;

using System.Security.Authentication;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class UserService : BreadService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IJsonWebTokenGenerator jsonWebTokenGenerator;        

        public UserService(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IJsonWebTokenGenerator jsonWebTokenGenerator,            
            IMapper mapper
        ) 
            : base(mapper)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.jsonWebTokenGenerator = jsonWebTokenGenerator;            
        }

        public async Task<string> LoginAsync(Authentication authentication)
        {
            BLL.User bllUser = await userRepository.GetByEmailAsync(authentication.EmailAddress);

            if (bllUser == null)
            {
                throw new AuthenticationException("Email address not found!");
            }

            var (passwordVerified, needsUpgrade) = passwordHasher.Check(bllUser.Password, authentication.Password);

            if (passwordVerified)
            {
                return jsonWebTokenGenerator.GenerateJsonWebToken(bllUser.Id, bllUser.LastName);    
            }

            throw new AuthenticationException("Incorrect password!");
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
