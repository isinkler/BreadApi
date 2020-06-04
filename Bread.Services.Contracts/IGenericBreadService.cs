using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bread.Services.Contracts
{
    public interface IGenericBreadService<TDto>
    {
        Task<TDto> GetAsync(int id);

        Task<IEnumerable<TDto>> GetAllAsync();

        Task<TDto> CreateAsync(TDto dto);

        Task<TDto> UpdateAsync(TDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
