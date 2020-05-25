using Bread.FileSystem.Contracts;

using System;
using System.IO;
using System.Threading.Tasks;

namespace Bread.FileSystem
{
    public class UploadsHandler : IUploadsHandler
    {        
        public async Task<string> PersistAsync(string path, byte[] bytes)
        {
            string fileName = Guid.NewGuid().ToString();

            path = Path.Combine(path, fileName);

            await File.WriteAllBytesAsync(path, bytes);

            return fileName;
        }
    }
}
