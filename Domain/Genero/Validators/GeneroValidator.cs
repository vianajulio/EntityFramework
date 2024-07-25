﻿using Domain.Genero.Requests;
using FluentValidation;

namespace Domain.Genero.Validators;

public class GeneroValidator : AbstractValidator<BaseGeneroRequest>
{
	public GeneroValidator()
	{
		RuleFor(x => x.Nome)
			.Null()
			.Empty()
			.WithMessage("O nome do gênero é obrigatório.");

		RuleFor(x => x.MaiorIdade)
			.Null()
			.Empty()
			.WithMessage("O valor de maior idade é obrigatório.");
	}
}