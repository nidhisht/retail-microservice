using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace OrderService.Extensions
{
    public static class SwaggerExtension
    {
        /// <summary>
        /// Extension method for adding Swagger configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Order Service",
                    Description = "Documentation for Order Microservice",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Nidhish T"
                    }
                });

                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                doc.IncludeXmlComments(xmlCommentFullPath);
            }
            );
        }

        /// <summary>
        /// Extension method for using swagger configuration
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public static void UseSwaggerExtension(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseSwagger();

            app.UseSwaggerUI(
                x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "This swagger v1 description"));

        }
    }
}
