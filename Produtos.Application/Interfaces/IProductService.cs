using Microsoft.AspNetCore.Http;
using Produtos.Application.Dtos.Base;
using Produtos.Application.Dtos.Products;

namespace Produtos.Application.Interfaces;
public interface IProductService
{
    Task<ProductDto> AddAsync(CreateProductDto createProductDto);
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<PagedResultDto<ProductDto>> GetAllAsync(PagedRequestDto dto);
    Task UpdateAsync(Guid id, UpdateProductDto updateProductDto);
    Task DeleteAsync(Guid id);
    Task<string> UploadAsync(IFormFile file);
}