using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Core.Messages.CommonMessages.DomainEvents;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
