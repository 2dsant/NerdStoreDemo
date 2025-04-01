
using EventStore.ClientAPI;

namespace EventSourcing;

public interface IEventStoreService
{
    IEventStoreConnection GetConnection();
}

public class EventStoreService : IEventStoreService
{
    public IEventStoreConnection GetConnection()
    {
        throw new NotImplementedException();
    }
}