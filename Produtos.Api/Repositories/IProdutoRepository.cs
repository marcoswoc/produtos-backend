using Produtos.Api.Entities;

namespace Produtos.Api.Repositories;

public interface IProdutoRepository
{
    public Task AddAsync(Produto produto);
    public Task UpdateAsync(Produto produto);
    public Task DeleteAsync(int id);
    public Task<Produto> GetByIdAsync(int id);
    public Task<IEnumerable<Produto>> GetAllAsync();
}
