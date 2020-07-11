using System;
using System.Threading.Tasks;
using Catalog.Api.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.ApiClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _catalogService.Search(new SearchQuery());
            return Ok(items);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<IActionResult> Get(long itemId)
        {
            var details = await _catalogService.Details(new DetailsQuery(itemId));
            return Ok(details);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(ItemDto[] items)
        {
            var result = await _catalogService.BatchUpdate(new BatchUpdateCommand(items));
            return Ok(result);
        }
    }
}