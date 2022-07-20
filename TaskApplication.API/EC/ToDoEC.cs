using Library.TaskManagement.Models;
using TaskApplication.API.Database;

namespace TaskApplication.API.EC
{
    public class ToDoEC
    {
        public List<ToDo> Get()
        {
            return FakeDatabase.ToDos;
        }
    }
}
