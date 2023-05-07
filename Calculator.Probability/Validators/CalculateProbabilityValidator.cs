using Calculator.Probability.Models;
using FluentValidation;

namespace Calculator.Probability.Validators;

internal sealed class CalculateProbabilityValidator : AbstractValidator<CalculateProbability>
{
    public const string ProbabilityRange = "Probability must be between 0 and 1";
    public const string Empty = "Probabilities cannot be empty";

    public CalculateProbabilityValidator()
    {
        RuleFor(request => request.Probabilities)
            .NotNull()
            .NotEmpty()
            .WithMessage(Empty)
            .Must(collection => collection.All(Probability.HasValidValue))
            .WithMessage(ProbabilityRange);
    }
}