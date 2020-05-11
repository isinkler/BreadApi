using Autofac;

using Bread.Repositories;
using Bread.Services;

namespace Bread.IoC
{
    public static class CompositionRoot
    {
        public static void RegisterModules(ContainerBuilder builder)
        {                        
            builder
                .RegisterModule<ServiceModule>();

            builder
                .RegisterModule<RepositoryModule>();
        }
    }
}
