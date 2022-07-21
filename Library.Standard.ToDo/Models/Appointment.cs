﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class Appointment: Item
    {
        public int Weight { get; set; }
        public int CartWeight { get; set; }
        public Appointment()
        {

        }
        public override string ToString()
        {
            return $"{Id}  - {Name} :: {Description}";
        }
    }
}
