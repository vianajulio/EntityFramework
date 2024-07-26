namespace Domain.Relacionamento.Request;

public record CriarLivroAutorRequest(Guid LivroCodigo, Guid AutorCodigo) : LivroAutorBaseRequest(LivroCodigo, AutorCodigo);
