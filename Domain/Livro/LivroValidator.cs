using Domain.Livro.Request;
using FluentValidation;

namespace Domain.Livro;
public class LivroValidator : AbstractValidator<BaseLivroRequest>
{
    public LivroValidator()
    {
        RuleFor(x => x.Titulo)
            .NotNull()
            .NotEmpty()
            .WithMessage("O título é obrigatório.");
        
        RuleFor(x => x.Tombo)
            .NotNull()
            .NotEmpty()
            .WithMessage("O tombo é obrigatório.");

        RuleFor(x => x.Genero)
            .NotNull()
            .NotEmpty()
            .WithMessage("O gênero é obrigatório.");
    }
}
