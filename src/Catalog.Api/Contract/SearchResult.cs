using System.Collections.Generic;

namespace Catalog.Api.Contract
{
    public class SearchResult
    {
        public IReadOnlyList<ItemDto> Items { get; set; }
    }
}