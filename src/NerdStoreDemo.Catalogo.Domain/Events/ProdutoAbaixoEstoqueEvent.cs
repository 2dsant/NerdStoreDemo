using NerdStoreDemo.Core.DomainObjects;

namespace NerdStoreDemo.Catalogo.Domain.Events;

public class ProdutoAbaixoEstoqueEvent : DomainEvent
{
    public int QuantidadeRestante { get; private set; }

    public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) 
        : base(aggregateId)
    {
        QuantidadeRestante = quantidadeRestante;
    }


}
