using Domain.Autor;
using Domain.Autor.Resquest;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class AutorService(IAutorRepository autorRepository, AutorValidator validator, ILivroAutorRepository livroAutorRepository) : IAutorService
{
	public async Task<Autor> CriarAutorAsync(CriarAutorRequest request)
	{
		var existe = await autorRepository.ExisteAutorAsync(request);

		if (existe)
			throw new Exception("O autor já está cadastrado.");

		var autor = Autor.CriarAutor(request, validator);

		await autorRepository.CriarAutorAsync(autor);

		return autor;
	}

	public async Task<Autor?> AtualizarAutorAsync(Guid id, AtualizarAutorRequest request)
	{
		var autor = await autorRepository.ObterAutorPorIdAsync(id) ?? throw new Exception("Autor não encontrado!");

		autor.AtualizarAutor(request, validator);
		await autorRepository.AtualizarAutorAsync();

		return autor;
    }

	public async Task DeleteAutorAsync(Guid autorId)
	{
		var temLivro = await livroAutorRepository.ExiteAutorAsync(autorId);

		if (temLivro) throw new Exception("Esse autor possui livro cadastrado!");

        await autorRepository.DeletarAutorAsync(autorId);
	}

	public async Task<Autor?> ObterPorIdAsync(Guid autorId)
	{
		var autor = await autorRepository.ObterAutorPorIdAsync(autorId);

		if (autor is null)
			throw new Exception("O autor não foi encontrado.");

		return autor;
	}

	public async Task<IReadOnlyCollection<Autor>> ObterTodosAutoresAsync()
		=> await autorRepository.ObterTodosAutoresAsync();
	
}
