using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ESVBible.Api.Utilities.Extensions.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers assembly types
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="assemblies"></param>
        public static void RegisterAssemblyTypes(
            this IServiceCollection serviceCollection,
            params Assembly[] assemblies)
        {
            serviceCollection.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }
    }
}