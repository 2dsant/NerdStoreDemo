using NerdStore.Catalogo.Application.ViewModels;
using NerdStoreDemo.Catalogo.Domain;
using AutoMapper;

namespace NerdStore.Catalogo.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        // construct using porque a Model utiliza construtor

        CreateMap<ProdutoViewModel, Produto>()
            .ConstructUsing(p =>
                new Produto(p.Nome, p.Descricao, p.Ativo,
                    p.Valor, p.CategoriaId, p.DataCadastro,
                    p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

        CreateMap<CategoriaViewModel, Categoria>()
            .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
    }
}
