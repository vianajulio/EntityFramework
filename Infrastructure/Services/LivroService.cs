using Domain.Livro;
using Domain.Livro.Request;
using Domain.Relacionamento.Request;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class LivroService(ILivroRepository livroRepository, ILivroAutorService livroAutorService, LivroValidator validator) : ILivroService
{

	public async Task<Livro> CriarLivroAsync(CriarLivroRequest request, Guid autorId)
	{
		var exise = await livroRepository.ExisteLivroAsync(request);

		if (exise)
			throw new Exception("Livro já cadastrado.");

		var livro = Livro.CriarLivro(request, validator);

		await livroAutorService.CriarLivroAutorAsync(new CriarLivroAutorRequest(livro.Codigo, autorId));

		await livroRepository.CriarLivroAsync(livro);

		return livro;
	}

	public async Task<Livro> AtualizarLivroAsync(Guid id, AtualizarLivroRequest request)
	{
		var oldLivro = await livroRepository.ObterLivroPorIdAsync(id);

		if (oldLivro is null)
			throw new Exception("Livro não encontrado.");

		var livro = Livro.AtualizarLivro(request, validator);

		await livroRepository.AtualizarLivroAsync(oldLivro, livro);

		return livro;
	}

	public async Task DeletarLivroAsync(Guid livroCodigo)
	{
		await livroRepository.DeletarLivroAsync(livroCodigo);

		await livroAutorService.DeletarLivroAutorAsync(livroCodigo);
	}

	public async Task<Livro?> ObterLivroPorIdAsync(Guid livroCodigo)
	{
		var livro = await livroRepository.ObterLivroPorIdAsync(livroCodigo);

		if (livro is null)
			throw new Exception("Nem um livro foi encontrado");

		return livro;
	}

	public async Task<IReadOnlyCollection<Livro>> ObterTodosLivrosAsync()
	{
		var livros = await livroRepository.ObterTodosLivrosAsync();

		foreach (var livro in livros)
		{
			var autores = await livroAutorService.ObterAutoresPorLivroCodigo(livro.Codigo);
			livro.Autores = autores;
		}

		return livros;
	}
}
