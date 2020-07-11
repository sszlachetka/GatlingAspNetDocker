using System.Collections.Generic;

namespace RateLimiting.LoadTests.Api.Contract
{
    public class SearchResult
    {
        public IReadOnlyList<ItemDto> Items { get; set; }
    }
}