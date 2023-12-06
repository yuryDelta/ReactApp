using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RankingApp.Models;


namespace RankingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly List<CurrencyConfig>? _options;
        public ItemsController(ILogger<ItemsController> logger, IOptions<CurrencyConfigOptions> options)
        {
            _logger = logger;
            _options = options?.Value?.Options;
        }

        //[Route("items/getitems")]
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return ItemsGenerator.GetConfiguredItems(_options).ToArray();
        }

    }
}
