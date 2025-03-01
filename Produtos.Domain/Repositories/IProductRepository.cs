using Produtos.Domain.Entities;
using Produtos.Domain.Repositories.Base;

namespace Produtos.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
}
