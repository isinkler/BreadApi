using System.IO;

namespace Bread.Common.Options
{
    public class StorageOptions
    {
        public string UploadsAbsolutePath { get; set; }

        public string RestaurantUploadsRelativePath { get; set; }

        public string UserUploadsRelativePath { get; set; }

        public string RestaurantUploadsAbsolutePath => Path.Combine(UploadsAbsolutePath, RestaurantUploadsRelativePath);

        public string UserUploadsAbsolutePath => Path.Combine(UploadsAbsolutePath, UserUploadsRelativePath);
    }
}
