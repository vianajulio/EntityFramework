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

	public async Task CriarLivroAutorAsync(LivroAutor livroAutor)
	{
		await _dataContext.AddAsync(livroAutor);
		await _dataContext.SaveChangesAsync();
	}

	public async Task DeletarLivroAutorAsync(LivroAutorBaseRequest request)
		=> await _dataContext.LivroAutor
			.Where(x =>
				x.LivroCodigo.Equals(request.LivroCodigo)
				&& x.AutorCodigo.Equals(request.AutorCodigo))
				.ExecuteDeleteAsync();

	public async Task<bool> ExiteAutorLivroAsync(LivroAutorBaseRequest livroAutor)
		=> await _dataContext.LivroAutor
			.AnyAsync(x =>
				x.LivroCodigo.Equals(livroAutor.LivroCodigo)
				&& x.AutorCodigo.Equals(livroAutor.AutorCodigo));

    public async Task<bool> ExiteAutorAsync(Guid autorId)
        => await _dataContext.LivroAutor
            .AnyAsync(x => x.AutorCodigo.Equals(autorId));

    public async Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivrosCodigo(Guid livroCodigo)
		=> await _dataContext.LivroAutor
		.Where(x => x.LivroCodigo.Equals(livroCodigo))
		.ToListAsync();

	public async Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo)
		=> await _dataContext.LivroAutor
		.Where(x => x.AutorCodigo.Equals(autorCodigo))
		.ToListAsync();
}
