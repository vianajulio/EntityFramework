using Domain.Relacionamento;
using Domain.Relacionamento.Request;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class LivroAutorService(ILivroAutorRepository repository, LivroAutorValidator validator) : ILivroAutorService
{
	public async Task<LivroAutor> CriarLivroAutorAsync(CriarLivroAutorRequest request)
	{
		var existe = await repository.ExiteAutorLivroAsync(request);

		if (existe)
			throw new Exception("Autor ou livro já estão vinculados.");

		var livroAutor = LivroAutor.CriarLivroAutor(request, validator);

		await repository.CriarLivroAutorAsync(livroAutor);

		return livroAutor;
	}

	public async Task DeletarLivroAutorAsync(Guid autorCodigo, Guid livroCodigo)
		=> await repository.DeletarLivroAutorAsync(autorCodigo, livroCodigo);

	public async Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivroCodigo(Guid livroCodigo)
		=> await repository.ObterAutoresPorLivrosCodigo(livroCodigo);

	public async Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo)
		=> await repository.ObterLivrosPorAutorCodigo(autorCodigo);
}
