using Library.TaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using TaskApplication.API.Database;
using TaskApplication.API.EC;

namespace TaskApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<ToDo> Get()
        {
            return new ToDoEC().Get();
        }

        [HttpPost("AddOrUpdate")]
        public ToDo AddOrUpdate(ToDo todo)
        {
            if (todo.Id <= 0)
            {
                todo.Id = FakeDatabase.NextId();
                FakeDatabase.ToDos.Add(todo);
            }

            var itemToUpdate = FakeDatabase.ToDos.FirstOrDefault(t => t.Id == todo.Id);
            if(itemToUpdate != null)
            {
                FakeDatabase.ToDos.Remove(itemToUpdate);
                FakeDatabase.ToDos.Add(todo);
            }

            return todo;
        }

        [HttpGet("Delete/{id}")]
        public int Delete(int id)
        {
            var itemToDelete = FakeDatabase.Items.FirstOrDefault(i => i.Id == id);
            if(itemToDelete != null)
            {
                var item = itemToDelete as ToDo;
                if(item != null)
                {
                    FakeDatabase.ToDos.Remove(item);
                }

            }

            return id;
        }
    }
}
