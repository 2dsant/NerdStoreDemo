using MediatR;
using NerdStoreDemo.Catalogo.Application.Services;
using NerdStoreDemo.Catalogo.Data;
using NerdStoreDemo.Catalogo.Domain.Events;
using NerdStoreDemo.Catalogo.Domain;
using NerdStoreDemo.Catalogo.Data.Repository;
using NerdStoreDemo.Vendas.Application.Commands;
using NerdStoreDemo.Vendas.Domain;
using NerdStoreDemo.Vendas.Data.Repository;
using NerdStoreDemo.Core.Communication.Mediator;
using NerdStoreDemo.Core.Messages.CommonMessages.Notifications;
using NerdStoreDemo.Vendas.Application.Queries;
using NerdStoreDemo.Vendas.Application.Events;

namespace NerdStoreDemo.WebApp.MVC.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Mediator
        services.AddScoped<IMediatorHandler, MediatrHandler>();

        // Notifications
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        // Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<CatalogoContext>();

        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

        // Vendas
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IPedidoQueries, PedidoQueries>();
        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();

        services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
        services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, PedidoEventHandler>();
        services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, PedidoEventHandler>();
    }
}
