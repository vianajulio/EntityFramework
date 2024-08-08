using Domain.Relacionamento;
using Domain.Relacionamento.Request;

namespace Infrastructure.Services;

public interface ILivroAutorService
{
	Task<LivroAutor> CriarLivroAutorAsync(CriarLivroAutorRequest livroAutor);
	Task DeletarLivroAutorAsync(Guid livroCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivroCodigo(Guid livroCodigo);
}
