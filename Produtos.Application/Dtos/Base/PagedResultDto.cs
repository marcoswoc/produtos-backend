namespace Produtos.Application.Dtos.Base;
public class PagedResultDto<Tdto> where Tdto : class
{
    public List<Tdto> Items { get; set; } = [];
    public int Total { get; set; }
    public int PageNumeber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}