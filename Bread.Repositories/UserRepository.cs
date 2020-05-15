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

        public Task<User> GetByEmailAndPasswordAsync(string emailAddress, string password)
        {
            emailAddress.ThrowIfNull(nameof(emailAddress));
            password.ThrowIfNull(nameof(password));

            return null;
        }
    }
}
