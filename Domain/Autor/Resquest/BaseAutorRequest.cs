namespace Domain.Autor.Resquest;

public record BaseAutorRequest(string Nome, DateTime DataNascimento, Guid GeneroFavoritoId);
