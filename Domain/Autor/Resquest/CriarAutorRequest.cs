namespace Domain.Autor.Resquest;

public record CriarAutorRequest(string Nome, DateTime DataNascimento, Guid GeneroFavoritoId) : BaseAutorRequest(Nome, DataNascimento, GeneroFavoritoId);
