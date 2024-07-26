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

	[HttpPut("edit")]
	public async Task<IActionResult> Put([FromBody] AtualizarAutorRequest autor)
	{
		var result = await _autorService.AtualizarAutorAsync(autor);

		return Ok(result);
	}

	[HttpGet("autorId")]
	public async Task<IActionResult> GetById(Guid autorId)
	{
		var result = await _autorService.ObterPorIdAsync(autorId);

		return Ok(result);
	}

}
