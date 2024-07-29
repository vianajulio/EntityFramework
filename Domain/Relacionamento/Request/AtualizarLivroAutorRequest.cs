namespace Domain.Relacionamento.Request;
using Livro;
using Autor;

public record AtualizarLivroAutorRequest(Guid CodigoLivro, Guid CodigoAutor, Livro Livro, Autor Autor) : LivroAutorBaseRequest(CodigoLivro, CodigoAutor);
