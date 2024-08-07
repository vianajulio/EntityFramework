using Domain.Autor;
using Domain.Autor.Resquest;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class AutorRepository : IAutorRepository
{
	private readonly DataContext _dataContext;

	public AutorRepository(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task AtualizarAutorAsync(Autor autor)
	{
		//var existGenero = await _dataContext.Genero.AnyAsync(x => x.Codigo.Equals(autor.GeneroFavoritoId));

		//if (!existGenero)
		//	throw new Exception("O genêro escolhido não existe na base de dados.");

		var oldAutor = await _dataContext.Autor.FirstOrDefaultAsync(x => x.Codigo.Equals(autor.Codigo));

		oldAutor!.Nome = autor.Nome;
		oldAutor!.DataNascimento = autor.DataNascimento;
		oldAutor!.GeneroFavorito = autor.GeneroFavorito;
		oldAutor!.Livros = autor.Livros;

		await _dataContext.SaveChangesAsync();
	}

	public async Task CriarAutorAsync(Autor autor)
	{
		await _dataContext.AddAsync(autor);
		await _dataContext.SaveChangesAsync();
	}

	public async Task DeletarAutorAsync(Guid autorCodigo)
		=> await _dataContext.Autor.Where(x => x.Codigo.Equals(autorCodigo)).ExecuteDeleteAsync();

	public async Task<bool> ExisteAutorAsync(BaseAutorRequest autor)
		=> await _dataContext.Autor.AnyAsync(
			x => x.Nome == autor.Nome
			&& x.DataNascimento == autor.DataNascimento
			&& x.GeneroFavorito == autor.GeneroFavoritoId);

	public async Task<Autor?> ObterAutorPorIdAsync(Guid autorId)
		=> await _dataContext.Autor.FirstOrDefaultAsync(x => x.Codigo.Equals(autorId));

	public async Task<IReadOnlyCollection<Autor>> ObterTodosAutoresAsync()
		=> await _dataContext.Autor.OrderBy(x => x.Nome).ToListAsync();

	public async Task<bool> ObterAutorPorGeneroAsync(Guid generoId) =>
		await _dataContext.Autor.AnyAsync(a => a.GeneroFavorito.Equals(generoId));
}
