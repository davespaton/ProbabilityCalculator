using Calculator.Probability.Calculate;
using Calculator.Probability.Models;

namespace Calculator.Probability;

internal interface IProbabilityCalculatorFactory
{
    ICalculate Get(CalculateProbability calculateProbability);
}

internal sealed class ProbabilityCalculatorFactory : IProbabilityCalculatorFactory
{
    public ICalculate Get(CalculateProbability calculateProbability)
    {
        (ProbabilityType type, IReadOnlyCollection<double> probabilities) = calculateProbability;
        int count = probabilities.Count;

        return type switch
        {
            ProbabilityType.Either when count == 2 => new Either(probabilities.First(), probabilities.Last()),
            ProbabilityType.CombinedWith when count == 2 => new CombinedWith(probabilities.First(), probabilities.Last()),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, $"Unable to find calculate for {type} with {count} probabilities")
        };
    }
}