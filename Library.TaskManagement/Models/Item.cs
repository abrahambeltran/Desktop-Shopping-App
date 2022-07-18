using Library.TaskManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class Item 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} :: {Description}";
        }


    }
}
