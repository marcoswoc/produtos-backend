using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Produtos.Domain.Repositories;
using Produtos.Infrastructure.Storage;
using Produtos.Persistence.Context;
using Produtos.Persistence.Repositories;

namespace Produtos.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {       
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    public static IServiceCollection AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AzureStorage") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddSingleton(new AzureStorageService(connectionString));

        return services;
    }

    public static void ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
        dbcontext.Database.Migrate();
    }
}

