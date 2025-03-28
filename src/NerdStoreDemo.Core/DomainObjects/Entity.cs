using NerdStoreDemo.Core.Messages;

namespace NerdStoreDemo.Core.DomainObjects;

// No DDD, uma entidade é um objeto com identidade própria,
// ou seja, mesmo que seus atributos mudem, ela ainda é a mesma entidade.
public abstract class Entity
{
    public Guid Id { get; set; }

    private List<Event> _notificacoes;
    public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

    public void AdicionarEvento(Event evento)
    {
        _notificacoes = _notificacoes ?? new List<Event>();
        _notificacoes.Add(evento);
    }

    public void RemoverEvento(Event evento)
    {
        _notificacoes?.Remove(evento);
    }

    public void LimparEventos()
    {
        _notificacoes?.Clear();
    }

    protected Entity() 
    {
        Id = Guid.NewGuid();
    }

    // Por padrão, o Equals verifica se dois objetos são a mesma referência na memória, ou seja, se apontam para o mesmo espaço.
    // Mas no DDD, entidades são identificadas pelo ID, não pela referência de memória.
    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity; // Tenta converter obj para Entity. Em falha retorna null

        if (ReferenceEquals(this, compareTo)) return true; // Se for a mesma instância, retorna true
        if (ReferenceEquals(null, compareTo)) return false; // Se for nulo, retorna false

        return Id.Equals(compareTo.Id); // Compara os IDs das entidades
    }

    public static bool operator == (Entity a, Entity b) 
    { 
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

        return a.Equals(b);
    }

    public static bool operator != (Entity a, Entity b)
    {
        return !(a == b);
    }

    // Por padrão, o método GetHashCode() da classe Object gera um número baseado na referência de memória do objeto.
    // Isso significa que, se tivermos dois objetos representando a mesma entidade (com o mesmo Id), eles poderiam ter hashes diferentes,
    // o que quebraria a consistência em estruturas como HashSet<>.
    public override int GetHashCode()
    {
        // Obtém o hash do tipo da entidade
        // Multiplica por um número primo p/ espalhar melhor os valores.
        // Somar com o Hash do Id garante que o hash ainda seja único por entidade
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    public virtual bool EhValido()
    {
        throw new NotImplementedException();
    }
}
