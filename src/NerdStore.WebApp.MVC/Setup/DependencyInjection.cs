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
using NerdStoreDemo.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStoreDemo.Vendas.Data;
using NerdStoreDemo.Pagamentos.Business;
using NerdStoreDemo.Pagamentos.AntiCorruption;
using NerdStoreDemo.Pagamentos.Data.Repository;
using EventSourcing;

namespace NerdStoreDemo.WebApp.MVC.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Mediator
        services.AddScoped<IMediatorHandler, MediatrHandler>();

        // Notifications
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

        // Event Sourcing
        services.AddSingleton<IEventStoreService, EventStoreService>();

        // Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<CatalogoContext>();

        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

        // Vendas
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IPedidoQueries, PedidoQueries>();
        services.AddScoped<VendasContext>();

        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoCommand, bool>, PedidoCommandHandler>();
        services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, PedidoCommandHandler>();

        services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
        services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, PedidoEventHandler>();
        services.AddScoped<INotificationHandler<PagamentoRealizadoEvent>, PedidoEventHandler>();
        services.AddScoped<INotificationHandler<PagamentoRecusadoEvent>, PedidoEventHandler>();

        // Pagamento
        services.AddScoped<IPagamentoRepository, PagamentoRepository>();
        services.AddScoped<IPagamentoService, PagamentoService>();
        services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
        services.AddScoped<IPayPalGateway, PayPalGateway>();
        services.AddScoped<Pagamentos.AntiCorruption.IConfigurationManager, NerdStoreDemo.Pagamentos.AntiCorruption.ConfigurationManager>();
        //services.AddScoped<PagamentoContext>();
    }
}
