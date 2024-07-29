using Domain.Livro;
using Domain.Livro.Request;

namespace Infrastructure.Services;

public interface ILivroService
{
	Task<Livro> CriarLivroAsync(CriarLivroRequest request);
	Task<Livro> AtualizarLivroAsync(AtualizarLivroRequest request);
	Task DeletarLivroAsync(Guid livroCodigo);
	Task<Livro?> ObterLivroPorIdAsync(Guid livroCodigo);
	Task<IReadOnlyCollection<Livro>> ObterTodosLivrosAsync();
}
