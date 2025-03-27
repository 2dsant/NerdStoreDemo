using NerdStoreDemo.Core.Messages.CommonMessages.Notifications;
using NerdStoreDemo.Core.Communication.Mediator;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace NerdStoreDemo.WebApp.MVC.Controllers;

public abstract class ControllerBase : Controller
{
    private readonly DomainNotificationHandler _notifications;
    private readonly IMediatorHandler _mediatorHandler;
    protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

    protected ControllerBase(INotificationHandler<DomainNotification> notification, 
        IMediatorHandler mediatorHandler)
    {
        _notifications = (DomainNotificationHandler)notification;
        this._mediatorHandler = mediatorHandler;
    }

    protected bool OperacaoValida()
    {
        return !_notifications.TemNotificacao();
    }

    protected IEnumerable<string> ObterMensagensErro()
    {
        return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
    }

    protected void NotificarErro(string codigo, string mensagem)
    {
        _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
    }
}
