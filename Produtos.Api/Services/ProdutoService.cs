using Produtos.Api.Entities;
using Produtos.Api.Models;
using Produtos.Api.Repositories;

namespace Produtos.Api.Services;

public class ProdutoService(IProdutoRepository _repository) : IProdutoService
{
    public async Task AddAsync(AdicionarProdutoModel produtoModel)
    {
        var produto = new Produto(
            produtoModel.Nome,
            produtoModel.Descricao,
            produtoModel.Preco,
            produtoModel.Categoria);        

        await _repository.AddAsync(produto);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProdutoModel>> GetAllAsync()
    {
        var produtos =  await _repository.GetAllAsync();
        var produtosModels = produtos.Select(ProdutoModel.ToModel);

        return produtosModels;
    }

    public async Task<ProdutoModel> GetByIdAsync(int id)
    {
        var produto = await _repository.GetByIdAsync(id);

        var produtoModel = ProdutoModel.ToModel(produto);

        return produtoModel;        
    }

    public async Task UpdateAsync(AtualizarProdutoModel produtoModel)
    {
        var produto = await _repository.GetByIdAsync(produtoModel.Id);

        if(produto is not null)
        {
            produto.Atualizar(
                produtoModel.Nome,
                produtoModel.Descricao,
                produtoModel.Preco,
                produtoModel.Categoria);

            await _repository.UpdateAsync(produto);
        }
        
    }
}
