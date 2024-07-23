namespace Domain.Genero.Requests;

public record AtualizarGeneroRequest(string Nome, bool MaiorIdade) : BaseGeneroRequest(Nome, MaiorIdade);
