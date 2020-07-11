using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Catalog.Api.Mock;
using Range = Catalog.Api.Mock.Range;

namespace Catalog.ApiClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Restricted load API", Version = "v1"});
            });

            services.AddCatalogServiceMock(
                new Range(
                    EnvironmentVariableInt("API_LATENCY_MIN_MS", 40) / 2,
                    EnvironmentVariableInt("API_LATENCY_MAX_MS", 80) / 2),
                "catalog-svc");
        }

        private static int EnvironmentVariableInt(string variableName, int defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(variableName);
            return value == null ? defaultValue : int.Parse(value);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restricted load API V1"); });
        }
    }
}