using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Core.DomainObjects;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
