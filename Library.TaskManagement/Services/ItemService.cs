using Library.TaskManagement.Models;
using Library.TaskManagement.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Services
{

    public class ItemService
    {
        private ListNavigator<Item> listNavigator;
        private List<Item> itemList;
        public List<Item> Items
        {
            get
            {
                return itemList;
            }
        }

        public int NextId
        {
            get
            {
                if (!Items.Any())
                {
                    return 1;
                }

                return Items.Select(t => t.Id).Max() + 1;
            }
        }

        private static ItemService current;

        public static ItemService Current
        {
            get
            {
                if (current == null)
                {
                    current = new ItemService();
                }

                return current;
            }
        }

        private ItemService()
        {
            itemList = new List<Item>();

            listNavigator = new ListNavigator<Item>(itemList);
        }

        public void Create(Item todo)
        {
            todo.Id = NextId;
            Items.Add(todo);
        }

        public void Update(Item? todo)
        {

        }

        public void Delete(int id)
        {
            var todoToDelete = itemList.FirstOrDefault(t => t.Id == id);
            if (todoToDelete == null)
            {
                return;
            }
            itemList.Remove(todoToDelete);
        }

        public void Load(string fileName)
        {
            var todosJson = File.ReadAllText(fileName);
            itemList = JsonConvert.DeserializeObject<List<Item>>
                (todosJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                ?? new List<Item>();

        }

        public void Save(string fileName)
        {
            var todosJson = JsonConvert.SerializeObject(itemList
                , new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(fileName, todosJson);
        }

        //GROSS
        //public IEnumerable<Item> Search(string query)
        //{
        //    return Items.Where(i => i.Description.Contains(query) || i.Name.Contains(query));
        //}

        //Stateful Implementation
        private string _query;
        private bool _sort;

        public IEnumerable<Item> Search(string query)
        {
            _query = query;
            return ProcessedList;
        }

        public IEnumerable<Item> ProcessedList{
            get
            {
                if(string.IsNullOrEmpty(_query))
                {
                    return Items;
                }
                return Items
                    .Where(i => string.IsNullOrEmpty(_query) ||( i.Description.Contains(_query)
                        || i.Name.Contains(_query))) //search
                    .OrderBy(i => i.Name);          //sort
            }
        }

    }
}
