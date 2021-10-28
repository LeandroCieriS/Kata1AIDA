using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StringCalculator.Application.Actions;
using StringCalculator.Application.Models;
using StringCalculator.Infrastructure;
using NSwag.AspNetCore;
using StringCalculator.Api.HealthChecks;

namespace StringCalculator.Api
{
    public class Startup
    {
        private const string DirPath = "./";
        private const string LogPath =  DirPath + "log.txt";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                Controllers.StringCalculator.Convention(options);
                Controllers.V1.StringCalculator.Convention(options);
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddHealthChecks().AddFileSystemHealthCheck(DirPath);
            services.AddControllers();
            services.AddScoped<GetStringCalculator>();
            services.AddScoped<CustomLogger, TextFileCustomLogger>(_ => new TextFileCustomLogger(LogPath));
            services.ConfigureSwagger("StringCalculator");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app
                .UseOpenApi()
                .UseSwaggerUi3(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerRoutes.Add( new SwaggerUi3Route(
                            description.GroupName.ToUpperInvariant(), 
                            $"/swagger/{description.GroupName}/swagger.json")
                        );
                    }
                })
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/status.json", new HealthCheckOptions
                    { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
                });
        }
    }
    public static class ServicesExtensions
    {
        public static IHealthChecksBuilder AddFileSystemHealthCheck(this IHealthChecksBuilder builder, string logFolderPath)
        {
            return builder.Add(new HealthCheckRegistration("Log Folder Health Check",
                _ => new LoggerHealthCheck(logFolderPath), null, null));
        }
    }
}