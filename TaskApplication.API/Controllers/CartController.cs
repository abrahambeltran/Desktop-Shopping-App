using Library.TaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using TaskApplication.API.EC;

namespace TaskApplication.API.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{cartName}")]
        public List<Item> Get(String cartName = "default")
        {
            return Get(cartName);
        }
        [HttpPost("AddOrUpdate")]
        public Item AddOrUpdate(Item item)
        {
            return new ToDoEC().AddOrUpdate(item);
        }
        [HttpGet("Delete/{id}")]
        public bool Delete(int id)
        {
            return new ToDoEC().Remove(id);
        }
    }
}
