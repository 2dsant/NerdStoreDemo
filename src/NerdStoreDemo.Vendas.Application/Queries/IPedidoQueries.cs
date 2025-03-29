using NerdStoreDemo.Vendas.Application.Queries.ViewModels;

namespace NerdStoreDemo.Vendas.Application.Queries;

public interface IPedidoQueries
{
    Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
    Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
}
