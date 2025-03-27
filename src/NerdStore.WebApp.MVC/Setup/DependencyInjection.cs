using MediatR;
using NerdStoreDemo.Catalogo.Application.Services;
using NerdStoreDemo.Catalogo.Data;
using NerdStoreDemo.Catalogo.Domain.Events;
using NerdStoreDemo.Catalogo.Domain;
using NerdStoreDemo.Core.Bus;
using NerdStoreDemo.Catalogo.Data.Repository;
using NerdStoreDemo.Vendas.Application.Commands;
using NerdStoreDemo.Vendas.Domain;
using NerdStoreDemo.Vendas.Data.Repository;

namespace NerdStoreDemo.WebApp.MVC.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, MediatrHandler>();

        // Catalogo
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<CatalogoContext>();

        services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

        // Vendas
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

    }
}
