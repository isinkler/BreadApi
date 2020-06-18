using AutoMapper;

using Bread.Common.Extensions;
using Bread.Data;
using Bread.Domain.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class UserRepository : BreadRepository, IUserRepository
    {
        public UserRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BLL.User> GetByEmailAsync(string emailAddress)
        {
            emailAddress.ThrowIfNull(nameof(emailAddress));            

            DAL.User dalUser = 
                await Context.Users.SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);

            User result = Mapper.Map<BLL.User>(dalUser);

            return result;
        }

        public async Task<BLL.User> CreateAsync(BLL.User user)
        {
            if (await GetByEmailAsync(user.EmailAddress) != null)
            {
                throw new ArgumentException("This email address is already being used!");
            }

            DAL.User dalUser = Mapper.Map<DAL.User>(user);

            Context.Users.Add(dalUser);
            await Context.SaveChangesAsync();

            User result = Mapper.Map<BLL.User>(dalUser);

            return result;
        }
    }
}
