using Domain.Genero.Requests;
using FluentValidation;

namespace Domain.Genero;

public class GeneroValidator : AbstractValidator<BaseGeneroRequest>
{
	public GeneroValidator()
	{
		RuleFor(x => x.Nome)
			.NotNull()
			.WithMessage("O nome do gênero é obrigatório.");

		RuleFor(x => x.MaiorIdade)
			.NotNull()
			.WithMessage("O valor de maior idade é obrigatório.");
	}
}
