using Domain.Genero;

namespace Infrastructure.Repository;

public interface IGeneroRepository
{
    Task GravarGeneroAsync(Genero genero);
    Task<Genero?> ObterGeneroAsync(Guid generoId);
    Task AtualizarGeneroAsync();
    Task DeletarGeneroAsync(Guid generoId);
    Task<bool> ExisteGeneroAsync(string generoNome);
    Task<IReadOnlyCollection<Genero>> ObterTodosGenerosAsync();
}