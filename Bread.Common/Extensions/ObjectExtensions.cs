using System;

namespace Bread.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull<T>(this T value, string paramName) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
