using Domain.Livro;
using Domain.Livro.Request;

namespace Infrastructure.Repository;

public interface ILivroRepository
{
	Task CriarLivroAsync(Livro livro);
	Task AtualizarLivroAsync(Livro livro);
	Task DeletarLivroAsync(Guid livroCodigo);
	Task<Livro?> ObterLivroPorIdAsync(Guid livroCodigo);
	Task<IReadOnlyCollection<Livro>> ObterTodosLivrosAsync();
	Task<bool> ExisteLivroAsync(BaseLivroRequest livro);
}
