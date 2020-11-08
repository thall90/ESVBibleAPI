using Microsoft.AspNetCore.Builder;

namespace ESVBible.Api.Utilities.Extensions.ApplicationBuilderExtensions
{
    public static class SwaggerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwashbuckle(
            this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Thrive Church Next Gen API v1");
            });
            
            return applicationBuilder;
        }
    }
}