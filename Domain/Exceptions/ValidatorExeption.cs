using FluentValidation;

namespace Domain.Exceptions;

public static class ValidatorExeption
{
	public static void ValidateCommand<TCommand>(this IValidator<TCommand> validator, TCommand command)
	{
		ArgumentNullException.ThrowIfNull(nameof(command));

		var validatorResult = validator.Validate(command);
		if (!validatorResult.IsValid)
			throw new ValidationException(validatorResult.Errors);
	}
}
