using Produtos.Domain.Enums;

namespace Produtos.Application.Dtos.Products;
public class UpdateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public string ImageUrl { get; set; }
}