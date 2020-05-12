using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpmeetEventSystem.Models
{
    public class JoinedEvent
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
