using Produtos.Api.Enums;

namespace Produtos.Api.Entities;

public class Produto(
    string nome,
    string descricao,
    decimal preco,
    CategoriaProduto categoria)
{    
    public int Id { get; private set; }
    public string Nome { get; private set; } = nome;
    public string Descricao { get; private set; } = descricao;
    public decimal Preco { get; private set; } = preco;
    public CategoriaProduto Categoria { get; private set; } = categoria;

    public void Atualizar(
        string nome,
        string descricao,
        decimal preco,
        CategoriaProduto categoria)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Categoria = categoria;       
    }
}
