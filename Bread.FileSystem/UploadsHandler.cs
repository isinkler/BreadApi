using Bread.DataTransfer;
using Bread.FileSystem.Contracts;

using System;
using System.IO;
using System.Threading.Tasks;

namespace Bread.FileSystem
{
    public class UploadsHandler : IUploadsHandler
    {        
        public async Task<string> PersistAsync(string path, BreadFile file)
        {
            string fileName = Guid.NewGuid().ToString() + file.Extension;

            path = Path.Combine(path, fileName);
           
            await File.WriteAllBytesAsync(path, file.Bytes);

            return fileName;
        }
    }
}
