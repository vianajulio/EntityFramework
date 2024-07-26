namespace Domain.Relacionamento.Request;

public record CriarLivroAutor(Guid Livro, Guid Autor) : LivroAutorBaseRequest(Livro, Autor);
