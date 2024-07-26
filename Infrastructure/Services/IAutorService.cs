using Domain.Autor;
using Domain.Autor.Resquest;

namespace Infrastructure.Services;

public interface IAutorService
{
	Task<Autor> CriarAutorAsync(CriarAutorRequest autor);
	Task<Autor> AtualizarAutorAsync(AtualizarAutorRequest autor);
	Task DeleteAutorAsync(Autor autor);
	Task<IReadOnlyCollection<Autor>> ObterTodosAutoresAsync();
	Task<Autor?> ObterPorIdAsync(Guid autorId);
}
