using NerdStoreDemo.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStoreDemo.Catalogo.Domain.Events;

public class ProdutoAbaixoEstoqueEvent : DomainEvent
{
    public int QuantidadeRestante { get; private set; }

    public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
    {
        QuantidadeRestante = quantidadeRestante;
    }
}
