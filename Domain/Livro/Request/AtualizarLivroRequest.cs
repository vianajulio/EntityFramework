namespace Domain.Livro.Request;

public record AtualizarLivroRequest(Guid Codigo, string Titulo, string Tombo, Guid Genero, IReadOnlyCollection<Guid> AutoresCodigo) : BaseLivroRequest(Titulo, Tombo, Genero);
