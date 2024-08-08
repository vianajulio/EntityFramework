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
	public async Task<IActionResult> Post([FromBody] CriarLivroRequest request, Guid autorId)
	{
		var livro = await _livroService.CriarLivroAsync(request, autorId);

		return Created("", livro);
	}

	[HttpGet]
	public async Task<IActionResult> ObterTodosLivros()
	{
		var livros = await _livroService.ObterTodosLivrosAsync();

		return Ok(livros);
	}

	[HttpGet("{id:guid}")]
	public async Task<IActionResult> ObterPorId(Guid id)
	{
		var result = await _livroService.ObterLivroPorIdAsync(id);

		return Ok(result);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> AtualizarLivro(Guid id, AtualizarLivroRequest request)
	{
		var result = await _livroService.AtualizarLivroAsync(id, request);

		return Ok(result);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> DeletarLivroPorId(Guid id)
	{
		await _livroService.DeletarLivroAsync(id);

		return Ok();
	}
}
