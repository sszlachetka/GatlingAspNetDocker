namespace Catalog.Service.Mock
{
    public class RandomCatalogOptions
    {
        public RandomCatalogOptions()
        {
            SearchResultCount = 100;
            SearchDurationRange = new DurationRange(100, 300);
            DetailsDurationRange = new DurationRange(50, 150);
            BatchUpdateDurationRange = new DurationRange(1100, 1500);
        }

        public int SearchResultCount { get; private set; }

        public DurationRange SearchDurationRange { get; private set; }
        public DurationRange DetailsDurationRange { get; private set; }
        public DurationRange BatchUpdateDurationRange { get; private set; }

        public RandomCatalogOptions SetSearchResultsCount(int value)
        {
            SearchResultCount = value;
            return this;
        }

        public RandomCatalogOptions SetSearchDuration(int min, int max)
        {
            SearchDurationRange = new DurationRange(min, max);
            return this;
        }

        public RandomCatalogOptions SetSearchDuration(int value)
        {
            return SetSearchDuration(value, value);
        }

        public RandomCatalogOptions SetDetailsDuration(int min, int max)
        {
            DetailsDurationRange = new DurationRange(min, max);
            return this;
        }

        public RandomCatalogOptions SetDetailsDuration(int value)
        {
            return SetDetailsDuration(value, value);
        }

        public RandomCatalogOptions SetBatchUpdateDuration(int min, int max)
        {
            BatchUpdateDurationRange = new DurationRange(min, max);
            return this;
        }

        public RandomCatalogOptions SetBatchUpdateDuration(int value)
        {
            return SetBatchUpdateDuration(value, value);
        }
    }
}