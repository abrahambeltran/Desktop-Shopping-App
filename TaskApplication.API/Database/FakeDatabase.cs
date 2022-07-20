using Library.TaskManagement.Models;

namespace TaskApplication.API.Database
{
    public static class FakeDatabase
    {
        public static List<Item> Items { 
            get
            {
                var returnList = new List<Item>();
                ToDos.ForEach(returnList.Add);
                Appointments.ForEach(returnList.Add);

                return returnList;
            }
        }

        public static List<ToDo> ToDos = new List<ToDo> { 
            new ToDo { Name = "Test ToDo1", Description = "Description 1", Id =1},
            new ToDo { Name = "Test ToDo2", Description = "Description 2", Id = 2},
            new ToDo { Name = "Test ToDo3", Description = "Description 3", Id = 3},
            new ToDo { Name = "Test ToDo4", Description = "Description 4", Id = 4},
            new ToDo { Name = "Test ToDo5", Description = "Description 5", Id = 5}
        };

        public static List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment { Name ="Test Appointment", Description= "Appointment 1", Id = 6},
            new Appointment { Name ="Test Appointment", Description= "Appointment 1", Id = 7},
            new Appointment { Name ="Test Appointment", Description= "Appointment 1", Id = 8},
            new Appointment { Name ="Test Appointment", Description= "Appointment 1", Id = 9}
        };

        public static int NextId()
        {
            if (!Items.Any())
            {
                return 1;
            }

            return Items.Select(t => t.Id).Max() + 1;

        }
    }
}
