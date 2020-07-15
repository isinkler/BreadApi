using Bread.DataTransfer;

using System.Threading.Tasks;

using DTO = Bread.DataTransfer;

namespace Bread.Services.Contracts
{
    public interface IRestaurantService : IGenericBreadService<DTO.Restaurant>
    {       
        Task<string> GetBannerAsync(int id);

        Task CreateBannerAsync(int id, BreadFile file);
    }
}
