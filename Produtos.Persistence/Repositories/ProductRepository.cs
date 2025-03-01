using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Persistence.Context;
using Produtos.Persistence.Repositories.Base;

namespace Produtos.Persistence.Repositories;
class ProductRepository(DataContext dbContext) : Repository<Product>(dbContext), IProductRepository
{    
}