using AutoMapper;
using Bread.Data;

namespace Bread.Repositories
{
    public abstract class BreadRepository
    {
        public BreadRepository(BreadDbContext dbContext, IMapper mapper)
        {
            Context = dbContext;
            Mapper = mapper;
        }

        public BreadDbContext Context { get; set; }

        public IMapper Mapper { get; set; }
    }
}
