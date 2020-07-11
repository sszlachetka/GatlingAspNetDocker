using System;
using System.Threading.Tasks;
using Catalog.Api.Contract;

namespace Catalog.Api.Mock
{
    internal class RandomCatalogService : ICatalogService
    {
        private readonly RandomCatalogOptions _options;
        private readonly RandomData _random;
        private readonly RandomDelayGenerator _randomDelayGenerator;

        public RandomCatalogService(RandomCatalogOptions options, RandomData random,
            RandomDelayGenerator randomDelayGenerator)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _random = random ?? throw new ArgumentNullException(nameof(random));
            _randomDelayGenerator =
                randomDelayGenerator ?? throw new ArgumentNullException(nameof(randomDelayGenerator));
        }

        public async Task<SearchResult> Search(SearchQuery query)
        {
            await _randomDelayGenerator.New(_options.SearchDurationRange);

            return new SearchResult
            {
                Items = _random.GenerateItemDtoCollection(_options.SearchResultCount)
            };
        }

        public async Task<DetailsResult> Details(DetailsQuery query)
        {
            await _randomDelayGenerator.New(_options.DetailsDurationRange);

            return new DetailsResult
            {
                Item = _random.GenerateItemDto(query.ItemId)
            };
        }

        public async Task<BatchUpdateResult> BatchUpdate(BatchUpdateCommand command)
        {
            await _randomDelayGenerator.New(_options.BatchUpdateDurationRange);

            return new BatchUpdateResult();
        }
    }
}