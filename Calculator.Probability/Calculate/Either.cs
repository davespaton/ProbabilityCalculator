namespace Calculator.Probability.Calculate;

internal sealed class Either : ICalculate
{
    private readonly Probability _pA;
    private readonly Probability _pB;

    public Either(Probability pA, Probability pB)
    {
        _pA = pA;
        _pB = pB;
    }
    public double Calculate() => _pA + _pB - (_pA * _pB);
}