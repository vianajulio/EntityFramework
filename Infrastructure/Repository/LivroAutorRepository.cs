using Domain.Relacionamento;
using Domain.Relacionamento.Request;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class LivroAutorRepository : ILivroAutorRepository
{
	private readonly DataContext _dataContext;

	public LivroAutorRepository(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	//public async Task AtualizarAutorPorLivroCodigoAsync(AtualizarLivroAutorRequest livroAutor)
	//{
	//	var autor = await _dataContext.Autor.FirstOrDefaultAsync(x =>
	//		x.Codigo.Equals(livroAutor.AutorCodigo));

	//	autor = livroAutor.Autor;

	//	await _dataContext.SaveChangesAsync();
	//}

	//public async Task AtualizarLivroPorAutorCodigoAsync(AtualizarLivroAutorRequest livroAutor)
	//{
	//	var oldLivroAutor = await _dataContext.LivroAutor
	//		.FirstOrDefaultAsync(x =>
	//			x.AutorCodigo.Equals(livroAutor.AutorCodigo)
	//			&& x.LivroCodigo.Equals(livroAutor.LivroCodigo));

	//	oldLivroAutor!.Livro = livroAutor.Livro;

	//	await _dataContext.SaveChangesAsync();
	//}

	public async Task CriarLivroAutorAsync(LivroAutor livroAutor)
	{
		await _dataContext.AddAsync(livroAutor);
		await _dataContext.SaveChangesAsync();
	}

	public async Task DeletarLivroAutorAsync(Guid autorCodigo, Guid livroCodigo)
		=> await _dataContext.LivroAutor
			.Where(x =>
				x.LivroCodigo.Equals(livroCodigo)
				&& x.AutorCodigo.Equals(autorCodigo))
				.ExecuteDeleteAsync();

	public async Task<bool> ExiteAutorLivroAsync(LivroAutorBaseRequest livroAutor)
		=> await _dataContext.LivroAutor
			.AnyAsync(x =>
				x.LivroCodigo.Equals(livroAutor.LivroCodigo)
				&& x.AutorCodigo.Equals(livroAutor.AutorCodigo));

	public async Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivrosCodigo(Guid livroCodigo)
		=> await _dataContext.LivroAutor
		.Where(x => x.LivroCodigo.Equals(livroCodigo))
		.OrderBy(x => x.Autor.Nome)
		.ToListAsync();

	public async Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo)
		=> await _dataContext.LivroAutor
		.Where(x => x.AutorCodigo.Equals(autorCodigo))
		.OrderBy(x => x.Livro.Titulo)
		.ToListAsync();
}
