using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;

namespace Produtos.Persistence.Context;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Produtcs { get; set; }
}

