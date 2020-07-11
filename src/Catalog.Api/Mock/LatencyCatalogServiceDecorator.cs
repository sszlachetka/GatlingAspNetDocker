using System;
using System.Threading.Tasks;
using Catalog.Api.Contract;

namespace Catalog.Api.Mock
{
    internal class LatencyCatalogServiceDecorator : ICatalogService
    {
        private readonly ICatalogService _decorated;
        private readonly Range _oneWayLatencyRange;
        private readonly RandomDelayGenerator _randomDelayGenerator;

        public LatencyCatalogServiceDecorator(ICatalogService decorated, Range oneWayLatencyRange,
            RandomDelayGenerator randomDelayGenerator)
        {
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
            _oneWayLatencyRange = oneWayLatencyRange ?? throw new ArgumentNullException(nameof(oneWayLatencyRange));
            _randomDelayGenerator =
                randomDelayGenerator ?? throw new ArgumentNullException(nameof(randomDelayGenerator));
        }

        public Task<SearchResult> Search(SearchQuery query)
        {
            return WithLatency(() => _decorated.Search(query));
        }

        public Task<DetailsResult> Details(DetailsQuery query)
        {
            return WithLatency(() => _decorated.Details(query));
        }

        public Task<BatchUpdateResult> BatchUpdate(BatchUpdateCommand command)
        {
            return WithLatency(() => _decorated.BatchUpdate(command));
        }

        private async Task<T> WithLatency<T>(Func<Task<T>> func)
        {
            await _randomDelayGenerator.New(_oneWayLatencyRange);

            var result = await func();

            await _randomDelayGenerator.New(_oneWayLatencyRange);

            return result;
        }
    }
}