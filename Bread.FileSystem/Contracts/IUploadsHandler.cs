using Bread.DataTransfer;
using System.Threading.Tasks;

namespace Bread.FileSystem.Contracts
{
    public interface IUploadsHandler
    {             
        Task<string> PersistAsync(string path, BreadFile file);
    }
}
