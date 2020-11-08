using ESVBible.Read.Query.Handler.EsvBible;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ThriveNextGen.Shared.Infrastructure.Read;
using ThriveNextGen.Shared.Infrastructure.Read.Query;

namespace ESVBible.Api.Utilities.Extensions.ServiceCollectionExtensions
{
    public static class QueryPipelineConfigurations
    {
        public static void AddQueryPipeline(
            this IServiceCollection serviceCollection)
        {
            AddMediator(serviceCollection);
            serviceCollection.AddTransient<IQueryPublisher, QueryPublisher>();
        }

        private static void AddMediator(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(GetEsvBookNamesInBiblicalOrderQueryHandler).Assembly);
        }
    }
}