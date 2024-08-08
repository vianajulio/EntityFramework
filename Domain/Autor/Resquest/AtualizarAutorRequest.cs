namespace Domain.Autor.Resquest;

public record AtualizarAutorRequest(string Nome, DateTime DataNascimento, Guid GeneroFavoritoId) : BaseAutorRequest(Nome, DataNascimento, GeneroFavoritoId);
