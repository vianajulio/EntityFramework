using Domain.Livro;
using Domain.Livro.Request;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class LivroService(ILivroRepository livroRepository, ILivroAutorService livroAutorService, LivroValidator validator) : ILivroService
{

	public async Task<Livro> CriarLivroAsync(CriarLivroRequest request)
	{
		var exise = await livroRepository.ExisteLivroAsync(request);

		if (exise)
			throw new Exception("Livro já cadastrado.");

		var livro = Livro.CriarLivro(request, validator);

		await livroRepository.CriarLivroAsync(livro);

		//await livroAutorService.CriarLivroAutorAsync();

		return livro;
	}

	public async Task<Livro> AtualizarLivroAsync(AtualizarLivroRequest request)
	{
		var exise = await livroRepository.ExisteLivroAsync(request);

		if (!exise)
			throw new Exception("Livro não encontrado.");
		var livro = Livro.AtualizarLivro(request, validator);

		await livroRepository.AtualizarLivroAsync(livro);

		return livro;
	}

	public async Task DeletarLivroAsync(Guid livroCodigo)
		=> await livroRepository.DeletarLivroAsync(livroCodigo);

	public async Task<Livro?> ObterLivroPorIdAsync(Guid livroCodigo)
	{
		var livro = await livroRepository.ObterLivroPorIdAsync(livroCodigo);

		if (livro is null)
			throw new Exception("Nem um livro foi encontrado");

		return livro;
	}

	public async Task<IReadOnlyCollection<Livro>> ObterTodosLivrosAsync()
		=> await livroRepository.ObterTodosLivrosAsync();
}
