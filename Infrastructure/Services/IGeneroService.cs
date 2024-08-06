using Domain.Genero;
using Domain.Genero.Requests;

namespace Infrastructure.Services;

public interface IGeneroService
{
    Task<Genero> AdicionarGeneroAsync(CriarGeneroRequest request);
    Task<Genero?> AtualizarGeneroAsync(Guid generoId, AtualizarGeneroRequest request);
    Task DeletarGeneroAsync(Guid id);
    Task<IReadOnlyCollection<Genero>> ObterTodosGenerosAsync();
    Task<Genero?> ObterPorIdAsync(Guid id);
}