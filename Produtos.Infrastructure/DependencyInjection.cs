using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Produtos.Domain.Repositories;
using Produtos.Persistence.Context;
using Produtos.Persistence.Repositories;

namespace Produtos.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}

