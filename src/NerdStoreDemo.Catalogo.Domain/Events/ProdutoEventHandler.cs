﻿using NerdStoreDemo.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStoreDemo.Core.Communication.Mediator;
using MediatR;

namespace NerdStoreDemo.Catalogo.Domain.Events;

public class ProdutoEventHandler : 
    INotificationHandler<ProdutoAbaixoEstoqueEvent>,
    INotificationHandler<PedidoIniciadoEvent>,
    INotificationHandler<PedidoProcessamentoCanceladoEvent>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEstoqueService _estoqueService;
    private IMediatorHandler _mediatorHandler;

    public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMediatorHandler mediatorHandler)
    {
        _produtoRepository = produtoRepository;
        _estoqueService = estoqueService;
        _mediatorHandler = mediatorHandler;
    }

    public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
    {
        var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

        // Enviar um email para aquisição de mais produtos.
        // Ou alguma outra lógica conforme a necessidade.
        
        Console.WriteLine("Evento foi tratado com sucesso!");
    }

    public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
    {
        var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

        if (result)
        {
            await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
        }
        else
        {
            await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
        }
    }

    public async Task Handle(PedidoProcessamentoCanceladoEvent message, CancellationToken cancellationToken)
    {
        await _estoqueService.ReporListaProdutosPedido(message.ProdutosPedido);
    }
}
