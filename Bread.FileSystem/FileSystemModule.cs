using Autofac;

using Bread.FileSystem.Contracts;

namespace Bread.FileSystem
{
    public class FileSystemModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<UploadsHandler>()
                .As<IUploadsHandler>()
                .InstancePerLifetimeScope();
        }
    }
}
