namespace Catalog.Api.Mock
{
    public class RandomCatalogOptions
    {
        public RandomCatalogOptions()
        {
            SearchResultCount = 100;
            SearchDurationRange = new Range(100, 300);
            DetailsDurationRange = new Range(50, 150);
            BatchUpdateDurationRange = new Range(1100, 1500);
        }

        public int SearchResultCount { get; private set; }

        public Range SearchDurationRange { get; private set; }
        public Range DetailsDurationRange { get; private set; }
        public Range BatchUpdateDurationRange { get; private set; }

        public RandomCatalogOptions SetSearchResultsCount(int value)
        {
            SearchResultCount = value;
            return this;
        }

        public RandomCatalogOptions SetSearchDuration(int min, int max)
        {
            SearchDurationRange = new Range(min, max);
            return this;
        }

        public RandomCatalogOptions SetSearchDuration(int value)
        {
            return SetSearchDuration(value, value);
        }

        public RandomCatalogOptions SetDetailsDuration(int min, int max)
        {
            DetailsDurationRange = new Range(min, max);
            return this;
        }

        public RandomCatalogOptions SetDetailsDuration(int value)
        {
            return SetDetailsDuration(value, value);
        }

        public RandomCatalogOptions SetBatchUpdateDuration(int min, int max)
        {
            BatchUpdateDurationRange = new Range(min, max);
            return this;
        }

        public RandomCatalogOptions SetBatchUpdateDuration(int value)
        {
            return SetBatchUpdateDuration(value, value);
        }
    }
}