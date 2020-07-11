using System.Collections.Generic;

namespace Catalog.Service.Contract
{
    public class SearchResult
    {
        public IReadOnlyList<ItemDto> Items { get; set; }
    }
}