using Produtos.Application.Dtos.Base;
using Produtos.Application.Dtos.Products;

namespace Produtos.Application.Interfaces;
public interface IProductService
{
    Task<ProductDto> AddAsync(CreateProductDto createProductDto);
    Task<ProductDto?> GetByIdAsync(Guid id);
    Task<PagedResultDto<ProductDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
    Task UpdateAsync(Guid id, UpdateProductDto updateProductDto);
    Task DeleteAsync(Guid id);
}