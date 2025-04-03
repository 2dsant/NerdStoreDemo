
using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing;

public interface IEventStoreService
{
    IEventStoreConnection GetConnection();
}
