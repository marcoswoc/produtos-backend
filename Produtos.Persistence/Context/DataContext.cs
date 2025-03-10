using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;

namespace Produtos.Persistence.Context;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Produtcs { get; set; }
}

