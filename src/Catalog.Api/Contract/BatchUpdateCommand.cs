using System.Collections.Generic;

namespace Catalog.Api.Contract
{
    public class BatchUpdateCommand
    {
        public BatchUpdateCommand(IReadOnlyCollection<ItemDto> items = null)
        {
            Items = items;
        }

        public IReadOnlyCollection<ItemDto> Items { get; }
    }
}