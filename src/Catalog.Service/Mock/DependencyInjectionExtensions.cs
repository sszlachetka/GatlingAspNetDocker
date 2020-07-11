using System;
using Catalog.Service.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Service.Mock
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCatalogServiceMock(this IServiceCollection services, RandomCatalogOptions options)
        {
            services.AddSingleton(options);
            services.AddSingleton<RandomData>();
            services.AddSingleton<RandomDelayGenerator>();

            services.AddTransient<ICatalogService, RandomCatalogService>();
        }
    }
}