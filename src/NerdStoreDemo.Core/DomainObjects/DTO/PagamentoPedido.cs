﻿namespace NerdStoreDemo.Core.DomainObjects.DTO;

public class PagamentoPedido
{
    public Guid PedidoId { get; set; }
    public Guid ClienteId { get; set; }
    public decimal Total { get; set; }
    public string NomeCartao { get; set; }
    public string NumeroCartao { get; set; }
    public string ExpiracaoCartao { get; set; }
    public string CvvCartao { get; set; }
}
