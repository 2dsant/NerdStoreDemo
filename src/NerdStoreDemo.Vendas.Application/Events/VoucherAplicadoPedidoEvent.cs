﻿using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Vendas.Application.Events;

public class VoucherAplicadoPedidoEvent : Event
{
    public Guid ClienteId { get; private set; }
    public Guid PedidoId { get; private set; }
    public Guid VoucherId { get; private set; }

    public VoucherAplicadoPedidoEvent(Guid clienteId, Guid pedidoId, Guid voucherId)
    {
        ClienteId = clienteId;
        PedidoId = pedidoId;
        VoucherId = voucherId;
    }
}
