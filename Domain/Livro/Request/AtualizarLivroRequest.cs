namespace Domain.Livro.Request;

public record AtualizarLivroRequest(string Titulo, string Tombo, Guid Genero) : BaseLivroRequest(Titulo, Tombo, Genero);
