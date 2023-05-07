using Calculator.Probability.Calculate;
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
    private readonly ILogger<IProbabilityCalculator> _logger;
    private readonly IValidator<CalculateProbability> _validator;
    private readonly IProbabilityCalculatorFactory _probabilityCalculatorFactory;

    public ProbabilityCalculator(
        ILogger<IProbabilityCalculator> logger,
        IValidator<CalculateProbability> validator,
        IProbabilityCalculatorFactory probabilityCalculatorFactory)
    {
        _logger = logger;
        _validator = validator;
        _probabilityCalculatorFactory = probabilityCalculatorFactory;
    }

    public ProbabilityResult Calculate(CalculateProbability calculateProbability)
    {
        ValidationResult? validationResponse = _validator.Validate(calculateProbability);
        if (validationResponse is not null && !validationResponse.IsValid)
        {
            return new ProbabilityResult(validationResponse.Errors);
        }

        ICalculate calculator = _probabilityCalculatorFactory.Get(calculateProbability);

        double result = calculator.Calculate();

        _logger.LogInformation("[{date}] Calculation for: {request} = {result}",
            DateTime.UtcNow,
            calculateProbability,
            result
        );

        return new ProbabilityResult(result);
    }
}
