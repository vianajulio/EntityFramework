using Domain.Livro.Request;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]

public class LivroController : ControllerBase
{
	private readonly ILivroService _livroService;

	public LivroController(ILivroService livroService)
	{
		_livroService = livroService;
	}

	[HttpPost]
	public async Task<IActionResult> Post(CriarLivroRequest request)
	{
		var livro = await _livroService.CriarLivroAsync(request);

		return Created("", livro);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var livros = await _livroService.ObterTodosLivrosAsync();

		return Ok(livros);
	}
}
