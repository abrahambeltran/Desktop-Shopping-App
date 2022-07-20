using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class ToDo: Item
    {
        public int Quantity { get; set; }

        public ToDo()
        {
            
        }

        public override string ToString()
        {
            return $"{Id} - {Name} :: {Description}";
        }
    }
}