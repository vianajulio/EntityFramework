using Domain.Genero;
using Domain.Genero.Requests;

namespace Infrastructure.Services;

public interface IGeneroService
{
	Task<Genero> AdicionarGeneroAsync(CriarGeneroRequest request);
	Task<Genero?> AtualizarGeneroAsync(AtualizarGeneroRequest request);
	Task DeletarGeneroAsync();
	Task<IReadOnlyCollection<Genero>> ObterGeneroAsync();
	Task<Genero?> ObterPorIdAsync(Guid id);
}
