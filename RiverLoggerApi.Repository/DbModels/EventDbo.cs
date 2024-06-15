using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLoggerApi.Repository.DbModels
{
    public class EventDbo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
