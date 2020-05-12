using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetEventSystem.Models
{
    public class Event
    {
        // ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
        // EventName varchar(80) NOT NULL,
        // Topic varchar(80) NOT NULL,
        // Description varchar(500) NOT NULL,
        // Location varchar(80) NOT NULL
        public int ID { get; set; }
        public string EventName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
