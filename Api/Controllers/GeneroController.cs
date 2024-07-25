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
}
