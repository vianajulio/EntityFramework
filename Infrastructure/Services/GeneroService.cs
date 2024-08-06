using Domain.Genero;
using Domain.Genero.Requests;
using Infrastructure.Repository;

namespace Infrastructure.Services;

public class GeneroService(IGeneroRepository generoRepository, GeneroValidator validator, IAutorRepository autorRepository, ILivroRepository livroRepository) : IGeneroService
{
    public async Task<Genero> AdicionarGeneroAsync(CriarGeneroRequest request)
    {
        var exist = await generoRepository.ExisteGeneroAsync(request.Nome);

        if (exist)
            throw new Exception("Genêro já cadastrado.");

        var genero = Genero.CriarGenero(request, validator);

        await generoRepository.GravarGeneroAsync(genero);

        return genero;
    }

    public async Task DeletarGeneroAsync(Guid id)
    {
        var existeAutor = await autorRepository.ObterAutorPorGeneroAsync(id);
        var existeLivro = await livroRepository.ObterLivroPorGeneroAsync(id);

        if (existeAutor) throw new Exception("Esse é o gênero favorito de um autor");
        if(existeLivro) throw new Exception("Existe livro com ese gênero");

        await generoRepository.DeletarGeneroAsync(id);
    }

    public async Task<Genero?> ObterPorIdAsync(Guid id)
    {
        return await generoRepository.ObterGeneroAsync(id);
    }

    public async Task<IReadOnlyCollection<Genero>> ObterTodosGenerosAsync()
    {
        return await generoRepository.ObterTodosGenerosAsync();
    }

    public async Task<Genero?> AtualizarGeneroAsync(Guid generoId, AtualizarGeneroRequest request)
    {
        var genero = await generoRepository.ObterGeneroAsync(generoId) ?? throw new Exception("Genero não encontrado!");

        genero.AtualizarGenero(request, validator);
        await generoRepository.AtualizarGeneroAsync();

        return genero;
    }
}