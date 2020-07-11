using System.Threading.Tasks;

namespace Catalog.Service.Contract
{
    public interface ICatalogService
    {
        Task<SearchResult> Search(SearchQuery query);
        Task<DetailsResult> Details(DetailsQuery query);
        Task<BatchUpdateResult> BatchUpdate(BatchUpdateCommand command);
    }
}