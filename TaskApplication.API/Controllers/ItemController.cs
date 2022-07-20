using Library.TaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using TaskApplication.API.Database;

namespace TaskApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController:ControllerBase
    {
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Item> Get()
        {
            return FakeDatabase.Items;
        }
    }
}
