
using BLL = Bread.Domain.Models;

namespace Bread.Repositories.Contracts
{
    public interface IOrderRepository : IGenericBreadRepository<BLL.Order>
    {
    }
}
