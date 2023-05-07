using Calculator.Probability.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Calculator.Probability;
public interface IProbabilityCalculator
{
    ProbabilityResult Calculate(CalculateProbability calculateProbability);
}

internal class ProbabilityCalculator : IProbabilityCalculator
{
    private readonly ILogger _logger;
    private readonly IValidator<CalculateProbability> _validator;

    public ProbabilityCalculator(
        ILogger logger,
        IValidator<CalculateProbability> validator)
    {
        _logger = logger;
        _validator = validator;
    }

    public ProbabilityResult Calculate(CalculateProbability calculateProbability)
    {
        ValidationResult? validationResponse = _validator.Validate(calculateProbability);
        if (validationResponse is not null && !validationResponse.IsValid)
        {
            return new ProbabilityResult(validationResponse.Errors);
        }

        double result = 0;

        return new ProbabilityResult(result);
    }
}
