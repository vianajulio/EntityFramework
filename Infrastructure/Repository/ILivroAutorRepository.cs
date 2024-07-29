using Domain.Relacionamento;
using Domain.Relacionamento.Request;

namespace Infrastructure.Repository;

public interface ILivroAutorRepository
{
	Task CriarLivroAutorAsync(LivroAutor livroAutor);
	//Task AtualizarLivroPorAutorCodigoAsync(AtualizarLivroAutorRequest autorCodigo);
	//Task AtualizarAutorPorLivroCodigoAsync(AtualizarLivroAutorRequest livroCodigo);
	Task DeletarLivroAutorAsync(Guid autorCodigo, Guid livroCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivrosCodigo(Guid livroCodigo);
	Task<bool> ExiteAutorLivroAsync(LivroAutorBaseRequest livroAutor);
}
