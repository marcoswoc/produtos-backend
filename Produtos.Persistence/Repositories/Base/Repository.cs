using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities.Base;
using Produtos.Domain.Repositories.Base;
using Produtos.Persistence.Context;
using System.Linq.Expressions;

namespace Produtos.Persistence.Repositories.Base;

public abstract class Repository<TEntity>(DataContext dbContext) : IRepository<TEntity>
    where TEntity : Entity
{
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is not null)
        {
            entity.MarkAsDeleted();
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<PagedResult<TEntity>> GetAllAsync(
        int pageNumber = 1,
        int pageSize = 10,
        Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = dbContext.Set<TEntity>()
            .AsQueryable()
            .AsNoTracking();

        if (filter is not null)
            query = query.Where(filter);

        var total = await query.CountAsync();

        var itens = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new()
        {
            Items = itens,
            Total = total,
            PageNumeber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<TEntity>()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        entity.MarkAsUpdated();
        dbContext.Update(entity);
        await dbContext.SaveChangesAsync();
    }
}

