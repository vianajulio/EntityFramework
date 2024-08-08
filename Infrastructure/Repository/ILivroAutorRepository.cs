using Domain.Relacionamento;
using Domain.Relacionamento.Request;

namespace Infrastructure.Repository;

public interface ILivroAutorRepository
{
	Task CriarLivroAutorAsync(LivroAutor livroAutor);
	Task DeletarLivroAutorAsync(Guid livroCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivrosCodigo(Guid livroCodigo);
	Task<bool> ExiteAutorLivroAsync(LivroAutorBaseRequest livroAutor);
	Task<bool> ExiteAutorAsync(Guid autorId);
}
