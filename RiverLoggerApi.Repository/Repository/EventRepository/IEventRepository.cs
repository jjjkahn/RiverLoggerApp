using RiverLoggerApi.Repository.DbModels;

namespace RiverLoggerApi.Repository.Repository.EventRepository
{
    public interface IEventRepository
    {
        Task CreateEvent(EventDbo eventModel);
        Task Delete(string id);
        Task<IEnumerable<EventDbo>> GetAllEventsByUserId(string id);
        Task<EventDbo> GetById(string id);
        Task Update(EventDbo user);
    }
}