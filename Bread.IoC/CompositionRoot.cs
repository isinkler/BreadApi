using Autofac;

using Bread.Data;
using Bread.Repositories;
using Bread.Services;

using Microsoft.EntityFrameworkCore;

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

        public static void RegisterModules(ContainerBuilder builder)
        {            
            builder
                .RegisterModule<ServiceModule>();

            builder
                .RegisterModule<RepositoryModule>();
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
