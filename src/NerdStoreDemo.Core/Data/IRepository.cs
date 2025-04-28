using NerdStoreDemo.Core.DomainObjects;

namespace NerdStoreDemo.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot // Regra de apenas um repositório por agregação
{
    IUnitOfWork UnitOfWork { get; }
}
