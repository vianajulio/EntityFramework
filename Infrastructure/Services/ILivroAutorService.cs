using Domain.Relacionamento;
using Domain.Relacionamento.Request;

namespace Infrastructure.Services;

public interface ILivroAutorService
{
	Task<LivroAutor> CriarLivroAutorAsync(CriarLivroAutorRequest livroAutor);
	//Task<AtualizarLivroAutorRequest> AtualizarLivroPorAutorCodigoAsync(AtualizarLivroAutorRequest autorCodigo);
	//Task<AtualizarLivroAutorRequest> AtualizarAutorPorLivroCodigoAsync(AtualizarLivroAutorRequest livroCodigo);
	Task DeletarLivroAutorAsync(Guid autorCodigo, Guid livroCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterLivrosPorAutorCodigo(Guid autorCodigo);
	Task<IReadOnlyCollection<LivroAutor>> ObterAutoresPorLivroCodigo(Guid livroCodigo);
}
