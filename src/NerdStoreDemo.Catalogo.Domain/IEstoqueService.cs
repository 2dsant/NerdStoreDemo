﻿namespace NerdStoreDemo.Catalogo.Domain;

public interface IEstoqueService : IDisposable
{
    Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
    Task<bool> ReporEstoque(Guid produtoId, int quantidade);
}
