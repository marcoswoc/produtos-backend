using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Produtos.Application.Interfaces;
using Produtos.Application.Services;
using System.Reflection;

namespace Produtos.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetAssembly(typeof(Profile)));

        return services;
    }
}
