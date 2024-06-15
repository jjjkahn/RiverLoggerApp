using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLoggerApi.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public IList<UserEvent> UserEvents { get; set; }
    }
}
