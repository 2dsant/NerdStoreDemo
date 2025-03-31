using System.Threading.Tasks;
using NerdStoreDemo.Core.DomainObjects.DTO;

namespace NerdStoreDemo.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}