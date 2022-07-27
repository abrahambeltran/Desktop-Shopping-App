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

        internal Item AddOrUpdate(Item item)
        {
            throw new NotImplementedException();
        }

        internal bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
