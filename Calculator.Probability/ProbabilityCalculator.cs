using Calculator.Probability.Models;
using Microsoft.Extensions.Logging;

namespace Calculator.Probability;
public interface IProbabilityCalculator
{
    ProbabilityResult Calculate(CalculateProbability calculateProbability);
}

internal class ProbabilityCalculator : IProbabilityCalculator
{
    private readonly ILogger<ProbabilityCalculator> _logger;

    public ProbabilityCalculator(ILogger<ProbabilityCalculator> logger)
    {
        _logger = logger;
    }

    public ProbabilityResult Calculate(CalculateProbability calculateProbability)
    {
        double result = 0;

        return new ProbabilityResult(result);
    }
}
