using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.Extensions
{
    public static class HealthCheckExtension
    {
        /// <summary>
        /// Extension method for adding Health Check configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddHealthCheckExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
        }

        /// <summary>
        /// Extension method for using Health Check configuration
        /// </summary>
        /// <param name="app"></param>
        public static void UseHealthCheckExtension(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthcheck", new HealthCheckOptions
            {
                Predicate = _ => true
            });
            app.UseHealthChecks("/api/healthcheck", new HealthCheckOptions
            {
                Predicate = registration => registration.Name == "self"
            });
            app.UseHealthChecks("/healthcheck-services", new HealthCheckOptions
            {
                Predicate = registration => registration.Tags.Contains("services")
            });
        }
    }
}
