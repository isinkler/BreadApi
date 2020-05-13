using Autofac;

using AutoMapper;

using Bread.DependencyInjection;

using System.Reflection;

using Module = Autofac.Module;

namespace Bread.AutoMapper
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
