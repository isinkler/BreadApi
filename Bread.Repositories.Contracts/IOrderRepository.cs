using Bread.Domain.Models;

using System.Threading.Tasks;

namespace Bread.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order bllOrder);

        Task<Order> UpdateAsync(Order bllOrder);
    }
}
