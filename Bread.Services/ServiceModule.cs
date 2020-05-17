using Autofac;

using Bread.Services.Contracts;

namespace Bread.Services
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RestaurantService>()
                .As<IRestaurantService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}
