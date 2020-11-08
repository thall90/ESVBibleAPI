// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Diagnostics.HealthChecks;
//
// namespace Bank.Write.Api.Utilities.Configurations
// {
//     public static class HealthCheckConfigurations
//     {
//         public static void AddBankWriteHealthChecks(
//             this IServiceCollection serviceCollection,
//             IConfiguration configuration)
//         {
//             serviceCollection.AddHealthChecks()
//                 .AddSqlServer(
//                     configuration.GetConnectionString(ConnectionConstants.EventStore),
//                     name: "Event Store Db",
//                     healthQuery: "SELECT 1;",
//                     failureStatus: HealthStatus.Unhealthy);
//         }
//
//         public static void AddHealthCheckUI(
//             this IServiceCollection serviceCollection)
//         {
//             serviceCollection.AddHealthChecksUI(setupSettings: setup =>
//             {
//                 setup.AddHealthCheckEndpoint("Bank Write Database Health", "/health-databases");
//                 setup.SetEvaluationTimeInSeconds(10);
//             });
//         }
//     }
// }