using Domain.Autor;
using Domain.Autor.Resquest;

namespace Infrastructure.Services;

public interface IAutorService
{
	Task<Autor> CriarAutorAsync(CriarAutorRequest autor);
	Task<Autor?> AtualizarAutorAsync(Guid autorId, AtualizarAutorRequest autor);
	Task DeleteAutorAsync(Guid id);
	Task<IReadOnlyCollection<Autor>> ObterTodosAutoresAsync();
	Task<Autor?> ObterPorIdAsync(Guid autorId);
}
