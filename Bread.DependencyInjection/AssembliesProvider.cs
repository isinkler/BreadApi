using System.IO;
using System.Linq;
using System.Reflection;

namespace Bread.DependencyInjection
{
    public static class AssembliesProvider
    {
        public static Assembly[] GetBreadAssemblies()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Assembly[] assemblies =
                Directory
                    .GetFiles(path, "Bread*.dll", SearchOption.TopDirectoryOnly)
                    .Select(Assembly.LoadFrom)
                    .ToArray();

            return assemblies;
        }
    }
}

