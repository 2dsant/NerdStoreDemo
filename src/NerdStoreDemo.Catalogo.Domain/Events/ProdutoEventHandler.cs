using MediatR;

namespace NerdStoreDemo.Catalogo.Domain.Events;

public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoEventHandler(IProdutoRepository produtoRepository)
    {
        this._produtoRepository = produtoRepository;
    }

    public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

        // Enviar um email para aquisição de mais produtos.
        // Ou alguma outra lógica conforme a necessidade.
        
        Console.WriteLine("Evento foi tratado com sucesso!");
    }
}
