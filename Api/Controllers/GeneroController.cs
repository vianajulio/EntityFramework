using Domain.Genero;
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

    [HttpGet]
    public async Task<IActionResult> ObterTodosGenerosAsync()
    {
        var gen = await _generoService.ObterTodosGenerosAsync();

        return gen is null ? NotFound() : Ok(gen);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorIdAsync(Guid id)
    {
        var gen = await _generoService.ObterPorIdAsync(id);

        return gen is null ? NotFound() : Ok(gen);
    }

    [HttpPost]
	public async Task<IActionResult> AdicionarGeneroAsync([FromBody] CriarGeneroRequest genero)
	{
		var gen = await _generoService.AdicionarGeneroAsync(genero);

		return gen is null ? NotFound() : Ok(gen);
	}
}
