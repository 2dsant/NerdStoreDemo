using MediatR;

namespace NerdStoreDemo.Core.Messages.CommonMessages.DomainEvents;

public abstract class DomainEvent : Message, INotification
{
    public DateTime Timestamp { get; set; }

    protected DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
        Timestamp = DateTime.UtcNow;
    }
}
