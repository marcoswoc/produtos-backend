using AutoMapper;
using Produtos.Application.Dtos.Base;
using Produtos.Domain.Repositories.Base;

namespace Produtos.Application.Mappers;
public class PagedResultProfile : Profile
{
    public PagedResultProfile()
    {
        CreateMap(typeof(PagedResult<>), typeof(PagedResultDto<>));
        CreateMap<PagedRequest, PagedRequestDto>();
    }
}

