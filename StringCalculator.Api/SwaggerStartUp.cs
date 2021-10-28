using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSwag;
using OpenApiOAuthFlow = Microsoft.OpenApi.Models.OpenApiOAuthFlow;
using OpenApiOAuthFlows = Microsoft.OpenApi.Models.OpenApiOAuthFlows;
using OpenApiSecurityScheme = Microsoft.OpenApi.Models.OpenApiSecurityScheme;

namespace StringCalculator.Api
{
    public static class SwaggerStartUp
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string productName)
        {
            for (var v = ApiVersioning.Min; v <= ApiVersioning.Current; v++)
            {
                AddSwaggerDocFor(services, productName, v);
            }
            return services;
        }

        private static void AddSwaggerDocFor(IServiceCollection services, string productName, int v)
        {
            var documentName = $"v{v}";
            services.AddSwaggerDocument(document => {
                document.DocumentName = documentName;
                document.Title = productName.ToUpper();
                document.Version = documentName;
                document.ApiGroupNames = new[] { $"v{v}" };
            });
        }
    }
}