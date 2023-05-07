using Calculator.Probability.Validators;

namespace Calculator.Probability;

internal readonly record struct Probability
{
    public double Value { get; }

    public Probability(double probability)
    {
        ThrowIfInvalid(probability);
        Value = probability;
    }

    private static void ThrowIfInvalid(double probability)
    {
        if (!HasValidValue(probability))
            throw new ArgumentOutOfRangeException(nameof(probability), CalculateProbabilityValidator.ProbabilityRange);
    }

    public static bool HasValidValue(double probability) => probability is >= 0 and <= 1;


    public static implicit operator Probability(double probability) => new(probability);

    public static implicit operator double(Probability probability) => probability.Value;
}