namespace Domain.Autor.Resquest;

using Domain.Relacionamento;

public record AtualizarAutorRequest(string Nome, DateTime DataNascimento, Guid GeneroId) : BaseAutorRequest(Nome, DataNascimento, GeneroId);
