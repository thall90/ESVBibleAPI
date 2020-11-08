using ESVBible.Api.Utilities.Serialization;
using ESVBible.Shared.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace ESVBible.Api.Utilities.Extensions.ServiceCollectionExtensions
{
    public static class UtilityConfigurations
    {
        public static void AddUtilityStack(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDataSerializer();
        }

        public static void AddDataSerializer(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IJsonDataSerializer, JsonDataSerializer>();
        }
    }
}