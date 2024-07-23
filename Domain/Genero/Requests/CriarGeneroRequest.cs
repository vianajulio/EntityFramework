namespace Domain.Genero.Requests;

public record CriarGeneroRequest(string Nome, bool MaiorIdade) : BaseGeneroRequest(Nome, MaiorIdade);
