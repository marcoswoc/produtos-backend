using Produtos.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Produtos.Domain.Repositories.Base;
public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<PagedResult<TEntity>> GetAllAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<TEntity, bool>>? filter = null);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}