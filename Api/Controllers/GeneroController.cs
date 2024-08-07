using Domain.Genero.Requests;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class GeneroController : ControllerBase
{
	private readonly IGeneroService _generoService;

	public GeneroController(IGeneroService generoService)
	{
		_generoService = generoService;
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CriarGeneroRequest genero)
	{
		var gen = await _generoService.AdicionarGeneroAsync(genero);

		return gen is null ? NotFound() : Ok(gen);
	}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> ObterGeneroPorId(Guid id)
	{
		var gen = await _generoService.ObterPorIdAsync(id);

        return gen is null ? NoContent() : Ok(gen);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodosGeneros()
    {
        var gen = await _generoService.ObterTodosGenerosAsync();

        return gen is null ? NoContent() : Ok(gen);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarGenero(Guid id, [FromBody] AtualizarGeneroRequest genero)
    {
        var gen = await _generoService.AtualizarGeneroAsync(id, genero);

        return gen is null ? NotFound() : Ok(gen);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletarGenero(Guid id)
    {
        await _generoService.DeletarGeneroAsync(id);
        return Ok();
    }
}
