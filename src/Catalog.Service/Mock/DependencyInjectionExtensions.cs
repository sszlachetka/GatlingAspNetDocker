using System;
using System.Diagnostics;
using Catalog.Service.Contract;
using Catalog.Service.Mock.TimeUtils;
using IdGen;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Service.Mock
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCatalogServiceMock(this IServiceCollection services, Range oneWayLatencyRange,
            string loggerName)
        {
            if (oneWayLatencyRange == null) throw new ArgumentNullException(nameof(oneWayLatencyRange));
            if (string.IsNullOrWhiteSpace(loggerName))
                throw new ArgumentException("Is null or whitespace", nameof(loggerName));

            services.AddSingleton(_ => Stopwatch.StartNew());
            services.AddSingleton(_ => new IdGenerator(0));
            services.AddSingleton<IDelayGenerator, TaskDelayGenerator>();
            services.AddSingleton<RandomData>();
            services.AddSingleton<RandomDelayGenerator>();

            services.AddTransient<ICatalogService>(provider =>
                new LatencyCatalogServiceDecorator(
                    new LoggingCatalogServiceDecorator(
                        new RandomCatalogService(
                            new RandomCatalogOptions(),
                            provider.GetRequiredService<RandomData>(),
                            provider.GetRequiredService<RandomDelayGenerator>()
                        ),
                        provider.GetRequiredService<Stopwatch>(),
                        provider.GetRequiredService<IdGenerator>(),
                        loggerName
                    ),
                    oneWayLatencyRange,
                    provider.GetRequiredService<RandomDelayGenerator>()
                )
            );
        }
    }
}