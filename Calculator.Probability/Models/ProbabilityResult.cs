using FluentValidation.Results;

namespace Calculator.Probability.Models;
public sealed record ProbabilityResult
{
    public double? Result { get; }

    public IReadOnlyCollection<ValidationFailure>? ValidationFailures { get; }

    public bool IsSuccess => Result is not null;

    public ProbabilityResult(double result)
    {
        Result = result;
    }

    public ProbabilityResult(IReadOnlyCollection<ValidationFailure> validationFailures)
    {
        ValidationFailures = validationFailures;
    }
}