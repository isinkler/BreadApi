using Autofac;

using Bread.Data;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Bread.DependencyInjection
{
    public static class CompositionRoot
    {
        public static void RegisterDbContext(ContainerBuilder builder, string connectionString)
        {
            builder
                .RegisterType<BreadDbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }

        public static void RegisterAssemblyModules(ContainerBuilder builder)
        {
            Assembly[] assemblies = AssembliesProvider.GetBreadAssemblies();

            builder.RegisterAssemblyModules(assemblies);
        }        

        private static DbContextOptions<BreadDbContext> GetDbContextConfiguration(string connectionString)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<BreadDbContext>();

            return 
                dbContextBuilder
                    .UseSqlServer(connectionString)
                    .Options;
        }
    }
}
