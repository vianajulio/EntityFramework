using Domain.Livro;
using Domain.Livro.Request;
using Domain.Relacionamento;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class LivroRepository : ILivroRepository
{
	private readonly DataContext _dataContext;

	public LivroRepository(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	public async Task AtualizarLivroAsync(Livro livro)
	{
		var oldLivro = _dataContext.Livro.FirstOrDefault(x => x.Codigo.Equals(livro.Codigo));

		oldLivro!.Titulo = livro.Titulo;
		oldLivro!.Tombo = livro.Tombo;
		oldLivro!.Genero = livro.Genero;

		var autores = await _dataContext.LivroAutor.Where(x => x.LivroCodigo.Equals(livro.Codigo)).ToListAsync();

		autores = livro.Autores.ToList();

		await _dataContext.SaveChangesAsync();
	}

	public async Task CriarLivroAsync(Livro livro)
	{
		await _dataContext.AddAsync(livro);

		await _dataContext.SaveChangesAsync();
	}

	public async Task DeletarLivroAsync(Guid livroCodigo)
		=> await _dataContext.Livro.Where(x => x.Codigo.Equals(livroCodigo)).ExecuteDeleteAsync();

	public async Task<bool> ExisteLivroAsync(BaseLivroRequest livro)
		=> await _dataContext.Livro
		.AnyAsync(
			x => x.Titulo.Equals(livro.Titulo)
			&& x.Tombo.Equals(livro.Tombo)
			&& x.Genero.Equals(livro.Genero));

	public async Task<Livro?> ObterLivroPorIdAsync(Guid livroCodigo)
		=> await _dataContext.Livro.FirstOrDefaultAsync(x => x.Codigo.Equals(livroCodigo));

	public async Task<IReadOnlyCollection<Livro>> ObterTodosLivrosAsync()
		=> await _dataContext.Livro.OrderBy(x => x.Titulo).ToListAsync();
}
