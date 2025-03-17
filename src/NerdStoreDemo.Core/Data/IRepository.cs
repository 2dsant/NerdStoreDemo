using NerdStoreDemo.Core.DomainObjects;

namespace NerdStoreDemo.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
