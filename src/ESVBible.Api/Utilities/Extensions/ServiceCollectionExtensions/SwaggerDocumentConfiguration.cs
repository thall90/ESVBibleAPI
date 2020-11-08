using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ESVBible.Api.Utilities.Extensions.ServiceCollectionExtensions
{
    public static class SwaggerDocumentConfiguration
    {
        /*public static IServiceCollection AddNSwag(
            this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerDocument(config =>
                {
                    config.PostProcess = document =>
                    {
                        document.Info.Version = "v1";
                        document.Info.Title = "Thrive Community Church Official API - Next Gen";
                        document.Info.Description = "The next generation of the Thrive Community Church Official API";
                        document.Info.TermsOfService = "None";
                        document.Info.Contact = new NSwag.OpenApiContact
                        {
                            Name = "Wyatt Baggett",
                            Email = string.Empty,
                            Url = "https://twitter.com/spboyer"
                        };
                    };
                });
        }*/

        public static IServiceCollection AddSwashbuckle(
            this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Thrive Community Church Official API - Next Gen",
                    Description = "The next generation of the Thrive Community Church Official API",
                    Contact = new OpenApiContact
                    {
                        Name = "Wyatt Baggett",
                        Email = "wyatt@thrive-fl.org",
                    },
                });
                
                config.IncludeXmlComments(GetXmlPathForAssembly());
            });
        }

        private static string GetXmlPathForAssembly()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}