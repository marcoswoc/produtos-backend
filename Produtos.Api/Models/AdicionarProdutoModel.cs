using Produtos.Api.Enums;

namespace Produtos.Api.Models;

public class AdicionarProdutoModel
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public CategoriaProduto Categoria { get; set; }
}
