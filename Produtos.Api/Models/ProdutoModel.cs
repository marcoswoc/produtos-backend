using Produtos.Api.Entities;
using Produtos.Api.Enums;

namespace Produtos.Api.Models;
public class ProdutoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public CategoriaProduto Categoria { get; set; }

    public static ProdutoModel ToModel(Produto produto) 
    {
        var model = new ProdutoModel();

        if (produto is not null)
        {
            model.Id = produto.Id;
            model.Nome = produto.Nome;
            model.Descricao = produto.Descricao;
            model.Preco = produto.Preco;
            model.Categoria = produto.Categoria;
        }

        return model;   
    }
}
