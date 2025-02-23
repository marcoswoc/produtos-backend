using Produtos.Domain.Enums;

namespace Produtos.Domain.Entities;

public class Product(
    string name,
    string description,
    decimal price,
    Category category,
    string imageUrl) : Entity()
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public decimal Price { get; private set; } = price;
    public Category Category { get; private set; } = category;
    public string ImageUrl { get; private set; } = imageUrl;
}