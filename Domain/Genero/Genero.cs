using Domain.Exceptions;
using Domain.Genero.Requests;
using Domain.Genero.Validators;

namespace Domain.Genero;

public class Genero
{
	public Guid Codigo { get; set; }
	public string Nome { get; set; } = default!;
	public bool MaiorIdade { get; set; }

	public Genero(string nome, bool maiorIdade)
	{
		Codigo = Guid.NewGuid();
		Nome = nome;
		MaiorIdade = maiorIdade;
	}

	public static Genero CriarGenero(CriarGeneroRequest command, GeneroValidator validator)
	{
		validator.ValidateCommand(command);

		return new Genero(command.Nome, command.MaiorIdade);
	}

	public void AtualizarGenero(AtualizarGeneroRequest command, GeneroValidator validator)
	{
		validator.ValidateCommand(command);

		Nome = command.Nome;
		MaiorIdade = command.MaiorIdade;
	}
}
