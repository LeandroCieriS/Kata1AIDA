using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StringCalculator.Application.Actions;
using StringCalculator.Application.Models;
using StringCalculator.Infrastructure;
using Microsoft.OpenApi.Models;
using StringCalculator.Api.HealthChecks;

namespace StringCalculator.Api
{
    public class Startup
    {
        private const string DirPath = "../Logs/";
        private const string LogPath =  DirPath + "log.txt";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning();
            services.AddHealthChecks().AddFileSystemHealthCheck(DirPath);
            services.AddControllers();
            services.AddScoped<GetStringCalculator>();
            services.AddScoped<ILogger, TextFileLogger>(_ => new TextFileLogger(LogPath));
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "String Calculator API");
            })
                .UseRouting()
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/status.json", new HealthCheckOptions
                { Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
            });
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName,
                    Description = "Foo API",
                    Contact = new OpenApiContact
                    {
                        Name = "Foo Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
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
