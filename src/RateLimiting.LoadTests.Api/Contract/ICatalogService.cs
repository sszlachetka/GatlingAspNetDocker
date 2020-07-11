using System.Threading.Tasks;

namespace RateLimiting.LoadTests.Api.Contract
{
    public interface ICatalogService
    {
        Task<SearchResult> Search(SearchQuery query);
        Task<DetailsResult> Details(DetailsQuery query);
        Task<BatchUpdateResult> BatchUpdate(BatchUpdateCommand command);
    }
}