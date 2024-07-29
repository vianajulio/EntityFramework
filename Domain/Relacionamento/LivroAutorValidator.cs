using Domain.Relacionamento.Request;
using FluentValidation;

namespace Domain.Relacionamento;

public class LivroAutorValidator : AbstractValidator<LivroAutorBaseRequest>
{
	public LivroAutorValidator()
	{
		RuleFor(x => x.AutorCodigo)
			.NotNull()
			.NotEmpty()
			.WithMessage("O codigo do autor é obrigatório.");

		RuleFor(x => x.LivroCodigo)
			.NotNull()
			.NotEmpty()
			.WithMessage("O codigo do livro é obrigatório.");
	}
}
