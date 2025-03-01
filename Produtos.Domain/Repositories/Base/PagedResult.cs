using Produtos.Domain.Entities.Base;

namespace Produtos.Domain.Repositories.Base;
public class PagedResult<Tentity> where Tentity : Entity
{
    public List<Tentity> Items { get; set; } = [];
    public int Total { get; set; }
    public int PageNumeber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
