using Domain.Autor;
using Domain.Autor.Resquest;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class AutorService(IAutorRepository autorRepository, AutorValidator validator) : IAutorService
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

	public async Task<Autor> AtualizarAutorAsync(AtualizarAutorRequest request)
	{
		var existe = await autorRepository.ExisteAutorAsync(request);

		if (!existe)
			throw new Exception("O autor não existe.");

		var autor = Autor.AtualizarAutor(request, validator);

		await autorRepository.AtualizarAutorAsync(autor);

		return autor;
	}

	public async Task DeleteAutorAsync(Autor autor)
		=> await autorRepository.DeletarAutorAsync(autor);

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
