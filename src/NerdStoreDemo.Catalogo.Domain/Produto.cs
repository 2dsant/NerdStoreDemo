using NerdStoreDemo.Core.DomainObjects;

namespace NerdStoreDemo.Catalogo.Domain;

public class Produto : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string Imagem { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public Categoria Categoria { get; private set; }
}

public class Categoria : Entity
{

}
