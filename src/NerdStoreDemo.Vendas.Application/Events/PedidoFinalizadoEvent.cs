﻿using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Vendas.Application.Events;

public class PedidoFinalizadoEvent : Event
{
    public Guid PedidoId { get; private set; }

    public PedidoFinalizadoEvent(Guid pedidoId)
    {
        PedidoId = pedidoId;
        AggregateId = pedidoId;
    }
}
