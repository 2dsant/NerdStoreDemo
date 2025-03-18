using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Core.Bus;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}
