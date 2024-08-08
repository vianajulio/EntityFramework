using Domain.Autor;
using Domain.Autor.Resquest;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class AutorController : ControllerBase
{
	private readonly IAutorService _autorService;

	public AutorController(IAutorService autorService)
	{
		_autorService = autorService;
	}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarAutorRequest autor)
    {
        var result = await _autorService.CriarAutorAsync(autor);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodosAutores()
    {
        var autor = await _autorService.ObterTodosAutoresAsync();

        return autor is null ? NoContent() : Ok(autor);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _autorService.ObterPorIdAsync(id);

        return Ok(result);
    }

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Put(Guid id,  AtualizarAutorRequest autor)
	{
		var result = await _autorService.AtualizarAutorAsync(id, autor);

		return Ok(result);
	}

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletarAutor(Guid id)
    {
        await _autorService.DeleteAutorAsync(id);
        return Ok();
    }
}
