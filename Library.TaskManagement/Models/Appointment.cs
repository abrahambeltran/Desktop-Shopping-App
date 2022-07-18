﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.TaskManagement.Models
{
    public class Appointment: Item
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<string> Attendees { get; set; }

        public override string ToString()
        {
            return $"{Id} ({Start:F} - {End:F}) - {Name} :: {Description}";
        }
    }
}
