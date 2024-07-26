using Domain.Autor.Resquest;
using FluentValidation;

namespace Domain.Autor;

public class AutorValidator : AbstractValidator<BaseAutorRequest>
{
	public AutorValidator()
	{
		RuleFor(x => x.Nome)
			.NotNull()
			.NotEmpty()
			.WithMessage("O nome do autor deve ser obrigatório.");

		RuleFor(x => x.DataNascimento)
			.NotNull()
			.NotEmpty()
			.WithMessage("A data de nascimento é obrigatória.");

		RuleFor(x => x.GeneroFavoritoId)
			.NotNull()
			.NotEmpty()
			.WithMessage("O genero favorito é obrigatório.");
	}
}
