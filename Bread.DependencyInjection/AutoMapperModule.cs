using Autofac;

using AutoMapper;

using System.Reflection;

using Module = Autofac.Module;

namespace Bread.DependencyInjection
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly[] assemblies = AssembliesProvider.GetBreadAssemblies();

            var mapperConfiguration =
                new MapperConfiguration(
                    config =>
                    {
                        config.AllowNullCollections = true;
                        config.AddMaps(assemblies);
                    }
                );

            IMapper mapper = mapperConfiguration.CreateMapper();

            builder.RegisterInstance(mapper);
        }
    }
}
