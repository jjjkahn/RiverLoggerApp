
namespace RiverLoggerApi.Repository.DbModels
{
    public class UserEventDbo
    {
        public string UserId { get; set; }
        public UserDbo User { get; set; }

        public string EventId { get; set; }
        public EventDbo Event { get; set; }
    }
}
