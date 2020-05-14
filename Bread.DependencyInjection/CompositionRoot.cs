using Autofac;

using System.Reflection;

namespace Bread.DependencyInjection
{
    public static class CompositionRoot
    {        
        public static void RegisterAssemblyModules(ContainerBuilder builder)
        {
            Assembly[] assemblies = AssembliesProvider.GetBreadAssemblies();

            builder.RegisterAssemblyModules(assemblies);
        }                
    }
}
