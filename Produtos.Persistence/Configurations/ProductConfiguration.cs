using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities;
using Produtos.Persistence.Configurations.Base;

namespace Produtos.Persistence.Configurations;

public class ProductConfiguration : BaseMap<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(product => product.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(product => product.Category)
            .HasConversion<string>()
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.ImageUrl)
            .HasMaxLength(500);

        base.Configure(builder);
    }
}

