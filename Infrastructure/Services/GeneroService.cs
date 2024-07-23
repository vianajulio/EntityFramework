using Domain.Genero;
using Domain.Genero.Requests;
using Domain.Genero.Validators;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class GeneroService(IGeneroRepository generoRepository, GeneroValidator validator) : IGeneroService
{
	public async Task<Genero> AdicionarGeneroAsync(CriarGeneroRequest request)
	{
		var exist = await generoRepository.ExisteGeneroAsync(request.Nome);

		if (exist)
			throw new Exception("Genêro já cadastrado.");

		var genero = Genero.CriarGenero(request, validator);

		await generoRepository.GravarGeneroAsync(genero);

		return genero;
	}

	public Task DeletarGeneroAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<Genero?> ObterPorIdAsync(Guid id)
	{
		return await generoRepository.ObterGeneroAsync(id);
	}

	public async Task<IReadOnlyCollection<Genero>> ObterTodosGenerosAsync()
	{
		return await generoRepository.ObterTodosGenerosAsync();
	}

	public Task<Genero?> UpdateGeneroAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Genero?> AtualizarGeneroAsync(AtualizarGeneroRequest request)
	{
        throw new NotImplementedException();
    }
}
