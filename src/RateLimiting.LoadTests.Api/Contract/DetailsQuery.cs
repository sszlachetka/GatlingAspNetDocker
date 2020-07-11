namespace RateLimiting.LoadTests.Api.Contract
{
    public class DetailsQuery
    {
        public DetailsQuery(long itemId = 1)
        {
            ItemId = itemId;
        }

        public long ItemId { get; }
    }
}