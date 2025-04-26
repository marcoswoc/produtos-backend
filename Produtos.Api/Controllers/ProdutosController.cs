using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Models;
using Produtos.Api.Services;

namespace Produtos.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutosController(IProdutoService _service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetAllAsync()
    {
        var produtos = await _service.GetAllAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoModel>> GetByIdAsync([FromRoute]int id)
    {
        var produto = await _service.GetByIdAsync(id);
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AdicionarProdutoModel model)
    {
        await _service.AddAsync(model);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AtualizarProdutoModel model)
    {
        model.Id = id;
        await _service.UpdateAsync(model);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
