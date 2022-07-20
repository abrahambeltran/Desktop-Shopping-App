using Library.TaskManagement.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Standard.ToDo.Utility
{
    public class ItemJsonConverter : JsonCreationConverter<Item>
    {
        protected override Item Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["deadline"] != null || jObject["Deadline"] != null)
            {
                return new TaskManagement.Models.ToDo();
            }
            else if (jObject["attendees"] != null || jObject["Attendees"] != null)
            {
                return new Appointment();
            }
            else
            {
                return new Item();
            }
        }
    }
}
