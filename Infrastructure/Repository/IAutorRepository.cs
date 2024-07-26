using Domain.Autor;
using Domain.Autor.Resquest;

namespace Infrastructure.Repository;

public interface IAutorRepository
{
	Task CriarAutorAsync(Autor autor);
	Task AtualizarAutorAsync(Autor autor);
	Task DeletarAutorAsync(Guid autorCodigo);
	Task<Autor?> ObterAutorPorIdAsync(Guid autorId);
	Task<IReadOnlyCollection<Autor>> ObterTodosAutoresAsync();
	Task<bool> ExisteAutorAsync(BaseAutorRequest autor);
}
