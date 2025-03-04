using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Entities.Base;

namespace Produtos.Persistence.Configurations.Base;
public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(entity => entity.UpdatedAt)
            .HasColumnType("DATETIME")
            .HasDefaultValue(null);

        builder.Property(entity => entity.DeletedAt)
            .HasColumnType("DATETIME")
            .HasDefaultValue(null);
        
        builder.Property(entity => entity.IsDeleted)            
            .HasDefaultValue(false)            
            .IsRequired();        
    }
}

