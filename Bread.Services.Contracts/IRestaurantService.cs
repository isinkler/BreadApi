using Bread.DataTransfer;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService : IGenericBreadService<DTO.Restaurant>
    {               
        Task AddImageAsync(int id, BreadFile file);
    }
}
