namespace Produtos.Domain.Entities;
public abstract class Entity
{
    protected Entity() 
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; init; }
    public DateTime CreateAt { get; protected set; }
    public DateTime? UpdateAt { get; protected set; }
    public DateTime? DeleteAt { get; protected set; }
}
