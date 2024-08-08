using Domain.Relacionamento.Request;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class LivroAutorController : ControllerBase
{
	private readonly ILivroAutorService _livroAutorService;

	public LivroAutorController(ILivroAutorService livroAutorService)
	{
		_livroAutorService = livroAutorService;
	}

	[HttpPost]
	public async Task<IActionResult> Post([FromBody] CriarLivroAutorRequest request)
	{
		var response = await _livroAutorService.CriarLivroAutorAsync(request);

		return Ok(response);
	}

	[HttpDelete]
	public async Task<IActionResult> Delete([FromBody] LivroAutorBaseRequest request)
	{
		await _livroAutorService.DeletarLivroAutorAsync(request);

		return Ok();
	}

	[HttpGet("autor/{id}")]
	public async Task<IActionResult> ObterLivrosPorAutorCodigo(Guid id)
	{
		var result = await _livroAutorService.ObterLivrosPorAutorCodigo(id);

		return Ok(result);
	}

	[HttpGet("livro/{id}")]
	public async Task<IActionResult> ObterAutoresPorLivroCodigo(Guid id)
	{
		var result = await _livroAutorService.ObterAutoresPorLivroCodigo(id);

		return Ok(result);
	}
}
