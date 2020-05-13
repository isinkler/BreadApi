﻿using Autofac;

using Bread.Data;

using Microsoft.EntityFrameworkCore;

using System.IO;
using System.Linq;
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

        public static void RegisterModules(ContainerBuilder builder)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Assembly[] assemblies =
                Directory
                    .GetFiles(path, "Bread*.dll", SearchOption.TopDirectoryOnly)
                    .Select(Assembly.LoadFrom)
                    .ToArray();

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
