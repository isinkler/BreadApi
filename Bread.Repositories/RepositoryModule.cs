using Autofac;

using Bread.Repositories.Contracts;

namespace Bread.Repositories
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RestaurantRepository>()
                .As<IRestaurantRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
