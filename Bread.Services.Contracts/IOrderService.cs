using Bread.DataTransfer;

using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Order order);


    }
}
