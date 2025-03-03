using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Dtos.Products;
using Produtos.Application.Interfaces;

namespace Produtos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService _service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateProductDto productDto)
    {
        var product = await _service.AddAsync(productDto);

        return Ok(product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
    {
        var product = await _service.GetByIdAsync(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }    

    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery]int pageNumber, [FromQuery]int pageSize)
    {
        var products = await _service.GetAllAsync(pageNumber, pageSize);

        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute]Guid id, [FromBody]UpdateProductDto productDto)
    {
        await _service.UpdateAsync(id, productDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
