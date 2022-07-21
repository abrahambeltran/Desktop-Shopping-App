using Library.TaskManagement.Models;
using Library.TaskManagement.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Services
{

    public class ItemService
    {
        private string persistPath 
            = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}";
        private ListNavigator<Item> listNavigator;
        private List<Item> itemList;
        private List<Item> cartList;
        public List<Item> Items
        {
            get
            {
                return itemList;
            }
        }
        public List<Item> Cart
        {
            get
            {
                return cartList;
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
        public int NextCartId
        {
            get
            {
                if (!Cart.Any())
                {
                    return 1;
                }

                return Cart.Select(t => t.Id).Max() + 1;
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
            cartList = new List<Item>();

            listNavigator = new ListNavigator<Item>(itemList);
            listNavigator = new ListNavigator<Item>(cartList);

        }

        public void AddOrUpdate(Item todo)
        {
            if (todo.Id <= 0)
            {
                todo.Id = NextId;
                Items.Add(todo);
            }

        }
        public void AddOrUpdateCart(Item todos)
        {
                Item cart = todos;
                cart.Id = todos.Id;
                Cart.Add(cart);
                
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
        public void DeleteFromCart(int id)
        {
            var todosToDelete = cartList.FirstOrDefault(t => t.Id == id);
            if (todosToDelete == null)
            {
                return;
            }
            cartList.Remove(todosToDelete);
        }

        public void Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = $"{persistPath}\\InventoryData.json";
            }
            else
            {
                fileName = $"{persistPath}\\{fileName}.json";
            }

            var todosJson = File.ReadAllText(fileName);
            itemList = JsonConvert.DeserializeObject<List<Item>>
                (todosJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                ?? new List<Item>();
        }
        public void Save(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                fileName = $"{persistPath}\\InventoryData.json";
            } else
            {
                fileName = $"{persistPath}\\{fileName}.json";
            }
            var todosJson = JsonConvert.SerializeObject(itemList
                , new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            File.WriteAllText(fileName, todosJson);
        }
        public void LoadCart(string fileName)
        {
            String s = fileName;
            fileName = $"{persistPath}\\{s}.json";

            var todosJson = File.ReadAllText(fileName);
            cartList = JsonConvert.DeserializeObject<List<Item>>
                (todosJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })
                ?? new List<Item>();
        }
        public void SaveCart(string fileName)
        {
            String s = fileName;
            fileName = $"{persistPath}\\{s}.json";
            var todosJson = JsonConvert.SerializeObject(cartList
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
