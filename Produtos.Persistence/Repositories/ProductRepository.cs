using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Persistence.Context;
using Produtos.Persistence.Repositories.Base;

namespace Produtos.Persistence.Repositories;
public class ProductRepository(DataContext dbContext) : Repository<Product>(dbContext), IProductRepository
{    
}