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

        public async Task<string> PersistAsync(byte[] file)
        {
            string fileName = Guid.NewGuid().ToString();

            using (var fileStream = new FileStream(options.UploadsPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return null;
        }
    }
}
