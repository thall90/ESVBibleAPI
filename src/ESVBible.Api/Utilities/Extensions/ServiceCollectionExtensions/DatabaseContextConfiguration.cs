using ESVBible.Data.Contexts;
using ESVBible.Shared.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESVBible.Api.Utilities.Extensions.ServiceCollectionExtensions
{
    public static class DatabaseContextConfiguration
    {
        public static void AddDatabaseContexts(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddEsvBibleContext(configuration);
        }

        private static void AddEsvBibleContext(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<EsvBibleContext>(builder =>
            {
                builder.UseNpgsql(configuration.GetConnectionString(ConnectionStringConstants.ThriveConnection));
            });

            serviceCollection.AddScoped<IEsvBibleContext, EsvBibleContext>();
        }
    }
}