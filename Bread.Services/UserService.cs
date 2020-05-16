using AutoMapper;

using Bread.Common.Options;
using Bread.DataTransfer;
using Bread.Repositories.Contracts;
using Bread.Security.Contracts;
using Bread.Services.Contracts;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DTO = Bread.DataTransfer;

namespace Bread.Services
{
    public class UserService : BreadService, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly SecurityOptions securityOptions;

        public UserService(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher, 
            IOptions<SecurityOptions> securityOptions,
            IMapper mapper
        ) 
            : base(mapper)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.securityOptions = securityOptions.Value;
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
                return GenerateJsonWebToken(bllUser);    
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

        private string GenerateJsonWebToken(BLL.User user)
        {
            SymmetricSecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityOptions.Jwt.SecretKey));

            SigningCredentials signingCredentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.LastName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token =
                new JwtSecurityToken(
                    issuer: securityOptions.Jwt.Issuer,
                    audience: securityOptions.Jwt.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(securityOptions.Jwt.ExpirationMinutes),
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
