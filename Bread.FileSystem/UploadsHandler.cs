using Bread.Common.Options;
using Bread.FileSystem.Contracts;

using Microsoft.Extensions.Options;

using System;
using System.IO;
using System.Threading.Tasks;

namespace Bread.FileSystem
{
    public class UploadsHandler : IUploadsHandler
    {
        private readonly StorageOptions options;

        public UploadsHandler(IOptions<StorageOptions> options)
        {
            this.options = options.Value;
        }

        public async Task<string> PersistAsync(byte[] bytes)
        {
            string fileName = Guid.NewGuid().ToString();
            string path = options.UploadsPath + fileName;

            await File.WriteAllBytesAsync(path, bytes);

            return path;
        }
    }
}
