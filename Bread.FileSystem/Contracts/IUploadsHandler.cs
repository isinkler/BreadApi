using System.Threading.Tasks;

namespace Bread.FileSystem.Contracts
{
    public interface IUploadsHandler
    {             
        Task<string> PersistAsync(string path, byte[] bytes);
    }
}
