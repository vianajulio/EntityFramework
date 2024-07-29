namespace Domain.Livro.Request;

public record CriarLivroRequest(string Titulo, string Tombo, Guid Genero) : BaseLivroRequest(Titulo, Tombo, Genero);
