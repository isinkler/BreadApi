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
            string fileName = GetFileName(file);

            CheckPath(path);

            path = Path.Combine(path, fileName);

            await File.WriteAllBytesAsync(path, file.Bytes);

            return fileName;
        }

        private static string GetFileName(BreadFile file)
        {
            return Guid.NewGuid().ToString() + file.Extension;
        }

        private static void CheckPath(string path)
        {
            bool folderExists = Directory.Exists(path);

            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
