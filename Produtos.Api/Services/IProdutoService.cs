using Produtos.Api.Models;

namespace Produtos.Api.Services;

public interface IProdutoService
{
    public Task AddAsync(AdicionarProdutoModel produtoModel);
    public Task UpdateAsync(AtualizarProdutoModel produtoModel);
    public Task DeleteAsync(int id);
    public Task<ProdutoModel> GetByIdAsync(int id);
    public Task<IEnumerable<ProdutoModel>> GetAllAsync();
}
