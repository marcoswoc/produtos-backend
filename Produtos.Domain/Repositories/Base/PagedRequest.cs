﻿namespace Produtos.Domain.Repositories.Base;
public class PagedRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

