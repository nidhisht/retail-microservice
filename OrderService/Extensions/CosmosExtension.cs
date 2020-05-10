using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Configuration;

namespace OrderService.Extensions
{
    public static class CosmosExtension
    {
        /// <summary>
        /// Extension method for adding Cosmos DB configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCosmosExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CosmosSettings>(configuration.GetSection("CosmosSettings"));
        }
    }
}
