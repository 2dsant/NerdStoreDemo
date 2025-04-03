using NerdStoreDemo.Core.Messages;
using MediatR;
using NerdStoreDemo.Core.Messages.CommonMessages.Notifications;
using NerdStoreDemo.Core.Data.EventSourcing;
using NerdStoreDemo.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStoreDemo.Core.Communication.Mediator;

public class MediatrHandler : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IEventSourcingRepository _eventSourcingRepository;

    public MediatrHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
    {
        _mediator = mediator;
        _eventSourcingRepository = eventSourcingRepository;
    }

    public async Task<bool> EnviarComando<T>(T comando) where T : Command
    {
        return await _mediator.Send(comando);
    }

    public async Task PublicarEvento<T>(T evento) where T : Event
    {
        await _mediator.Publish(evento);

        if (!evento.GetType().BaseType.Name.Equals("DomainEvent"))
            await _eventSourcingRepository.SalvarEvento(evento);
    }

    public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
    {
        await _mediator.Publish(notificacao);
    }

    public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
    {
        await _mediator.Publish(notificacao);
    }
}
