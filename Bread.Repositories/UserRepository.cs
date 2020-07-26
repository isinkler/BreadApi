using AutoMapper;

using Bread.Common.Extensions;
using Bread.Data;
using Bread.Data.Models;
using Bread.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

using BLL = Bread.Domain.Models;
using DAL = Bread.Data.Models;

namespace Bread.Repositories
{
    public class UserRepository : GenericBreadRepository<DAL.User, BLL.User>, IUserRepository
    {
        public UserRepository(BreadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<BLL.User> GetByEmailAsync(string emailAddress)
        {
            emailAddress.ThrowIfNull(nameof(emailAddress));            

            DAL.User dalUser = 
                await Context.Users.SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);

            var result = Mapper.Map<BLL.User>(dalUser);

            return result;
        }

        public async override Task<BLL.User> CreateAsync(BLL.User user)
        {
            if (await GetByEmailAsync(user.EmailAddress) != null)
            {
                throw new ArgumentException("This email address is already being used!");
            }

            var dalUser = Mapper.Map<DAL.User>(user);

            Context.Users.Add(dalUser);
            await Context.SaveChangesAsync();

            var result = Mapper.Map<BLL.User>(dalUser);

            return result;
        }

        protected override IQueryable<User> GetEntities()
        {
            throw new NotImplementedException();
        }
    }
}
