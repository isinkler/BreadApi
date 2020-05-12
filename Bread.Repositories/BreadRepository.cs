using Bread.Data;

namespace Bread.Repositories
{
    public abstract class BreadRepository
    {
        public BreadRepository(BreadDbContext dbContext)
        {
            Context = dbContext;
        }

        public BreadDbContext Context { get; set; }
    }
}
