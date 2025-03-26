using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Core.Bus;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
    Task<bool> EnviarComando<T>(T comando) where T : Command;
}
