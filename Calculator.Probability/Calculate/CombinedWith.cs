namespace Calculator.Probability.Calculate;

internal sealed class CombinedWith : ICalculate
{
    private readonly Probability _pA;
    private readonly Probability _pB;

    public CombinedWith(Probability pA, Probability pB)
    {
        _pA = pA;
        _pB = pB;
    }
    public Probability Calculate() => _pA * _pB;
}