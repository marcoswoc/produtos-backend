using AutoMapper;
using Microsoft.AspNetCore.Http;
using Produtos.Application.Dtos.Base;
using Produtos.Application.Dtos.Products;
using Produtos.Application.Interfaces;
using Produtos.Domain.Entities;
using Produtos.Domain.Repositories;
using Produtos.Infrastructure.Storage;

namespace Produtos.Application.Services;
public class ProductService(
    IProductRepository _repository,
    AzureStorageService _azureStorageService,
    IMapper _mapper) : IProductService
{
    public async Task<ProductDto> AddAsync(CreateProductDto createProductDto)
    {
        var product = new Product(
            createProductDto.Name,
            createProductDto.Description,
            createProductDto.Price,
            createProductDto.Category,
            createProductDto.ImageUrl);
         
        await _repository.AddAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<PagedResultDto<ProductDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        var products = await _repository.GetAllAsync(pageNumber, pageSize);

        return _mapper.Map<PagedResultDto<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateAsync(Guid id, UpdateProductDto updateProductDto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is not null)
        {
            product.Update(
                updateProductDto.Name,
                updateProductDto.Description,
                updateProductDto.Price,
                updateProductDto.Category,
                updateProductDto.ImageUrl);

            await _repository.UpdateAsync(product);
        }
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        using var stream = file.OpenReadStream();

        return await _azureStorageService.UploadBlobAsync("produto-image", file.Name, stream);
    }
}

