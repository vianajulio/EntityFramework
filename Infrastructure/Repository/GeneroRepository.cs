using Domain.Genero;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GeneroRepository : IGeneroRepository
{
	private readonly DataContext _dataContext;

	public GeneroRepository(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public Task AtualizarGeneroAsync(Guid generoId, Genero generoAtualizado)
	{
		throw new NotImplementedException();
	}

	public Task DeletarGeneroAsync(Guid generoId)
	{
		throw new NotImplementedException();
	}

	public Task<bool> ExisteGeneroAsync(string generoNome)
		=> _dataContext.Genero.AnyAsync(x => x.Nome.Equals(generoNome));

	public async Task GravarGeneroAsync(Genero genero)
	{
		await _dataContext.Genero.AddAsync(genero);
		await _dataContext.SaveChangesAsync();
	}

	public Task<Genero> ObterGeneroAsync(Guid generoId)
	{
		throw new NotImplementedException();
	}

	public Task<IReadOnlyCollection<Genero>> ObterTodosGenerosAsync()
	{
		throw new NotImplementedException();
	}
}
