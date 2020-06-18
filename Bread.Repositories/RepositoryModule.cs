using Autofac;

using Bread.Repositories.Contracts;

namespace Bread.Repositories
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<RestaurantRepository>()
                .As<IRestaurantRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();            
        }
    }
}
