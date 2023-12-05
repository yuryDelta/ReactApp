using Microsoft.AspNetCore.Mvc;
using RankingApp.Models;

namespace RankingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }

        //[Route("items/getitems")]
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return ItemsGenerator.GetItems().ToArray();
        }

    }
}
