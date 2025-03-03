using AutoMapper;
using Produtos.Application.Dtos.Products;
using Produtos.Domain.Entities;

namespace Produtos.Application.Mappers;
public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();        
    }
}
