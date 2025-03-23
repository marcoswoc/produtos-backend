using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Dtos.Base;
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
    public async Task<IActionResult> GetAsync([FromQuery]PagedRequestDto dto)
    {
        var products = await _service.GetAllAsync(dto);

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

    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync([FromBody] IFormFile file)
    {
        if (file is null || file.Length > 0)
            return BadRequest("Nenhum arquivo enviado.");

        const long maxSizeBytes = 2 * 1024 * 1024;
        if (file.Length > maxSizeBytes)
            return BadRequest($"O arquivo excede o tamanho máximo de 2MB. O tamanho atual é {file.Length / 1024 / 1024}MB.");

        var allowedMimeTypes = new[] { "image/jpeg", "image/png", "iamge/jpg" };
        if (!allowedMimeTypes.Contains(file.ContentType))
            return BadRequest("Tipo de arquivo não permitido. Apenas .jpg, .jpeg e .png são aceitos.");

        var blobUrl = await _service.UploadAsync(file);

        return Ok(blobUrl);
    }
}
