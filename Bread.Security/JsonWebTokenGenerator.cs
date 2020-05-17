using Bread.Common.Options;
using Bread.Security.Contracts;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bread.Security
{
    public class JsonWebTokenGenerator : IJsonWebTokenGenerator
    {
        private readonly JwtOptions options;

        public JsonWebTokenGenerator(IOptions<SecurityOptions> securityOptions)
        {
            options = securityOptions.Value.Jwt;
        }

        public string GenerateJsonWebToken(int id, string lastName)
        {
            SymmetricSecurityKey securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));

            SigningCredentials signingCredentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token =
                new JwtSecurityToken(
                    issuer: options.Issuer,
                    audience: options.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(options.ExpirationMinutes),
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
