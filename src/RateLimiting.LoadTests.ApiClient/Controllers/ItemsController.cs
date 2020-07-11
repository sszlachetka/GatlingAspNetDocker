using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateLimiting.LoadTests.Api.Contract;

namespace RateLimiting.LoadTests.ApiClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public ItemsController(ICatalogService catalogService)
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