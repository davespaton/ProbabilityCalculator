using Calculator.Probability.Models;
using Calculator.Probability.Validators;
using FakeItEasy;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Calculator.Probability.Tests;

public class EitherCalculatorTests
{
    private readonly ILogger _logger;

    public EitherCalculatorTests()
    {
        _logger = A.Fake<ILogger>();
    }

    private ProbabilityCalculator GetProbabilityCalculator() => new(_logger, new CalculateProbabilityValidator());

    private static ProbabilityResult Calculate(ProbabilityCalculator calculator, double pA, double pB)
    {
        CalculateProbability calculateProbability  = new (ProbabilityType.Either, new [] { pA, pB });
        return calculator.Calculate(calculateProbability);
    }

    [Fact]
    public void Calculate_EmptyProbabilities_ReturnsErrors()
    {
        // Arrange
        ProbabilityCalculator calculator = GetProbabilityCalculator();

        // Act
        ProbabilityResult actual = calculator.Calculate(new CalculateProbability(ProbabilityType.Either, Array.Empty<double>()));

        // Assert
        Assert.False(actual.IsSuccess);
        Assert.Null(actual.Result);

        ValidationFailure failure = actual.ValidationFailures!.Single();
        Assert.Equal(nameof(CalculateProbability.Probabilities), failure.PropertyName);
        Assert.Equal(CalculateProbabilityValidator.Empty, failure.ErrorMessage);
    }

    [Theory]
    [InlineData(-1, 0.5)]
    [InlineData(0.5, -1)]
    [InlineData(1.00001, 0.5)]
    [InlineData(double.MaxValue, 0.5)]
    public void Calculate_InvalidProbabilities_ReturnsErrors(double pA, double pB)
    {
        // Arrange
        ProbabilityCalculator calculator = GetProbabilityCalculator();

        // Act
        ProbabilityResult actual = Calculate(calculator, pA, pB);

        // Assert
        Assert.False(actual.IsSuccess);
        Assert.Null(actual.Result);

        ValidationFailure failure = actual.ValidationFailures!.Single();
        Assert.Equal(nameof(CalculateProbability.Probabilities), failure.PropertyName);
        Assert.Equal(CalculateProbabilityValidator.ProbabilityRange, failure.ErrorMessage);
    }

    [Theory]
    [InlineData(0.5, 0.5, 0.75)]
    [InlineData(0.25, 0.25, 0.4375)]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    public void Calculate_Valid_ReturnsResult(double pA, double pB, double result)
    {
        // Arrange
        ProbabilityCalculator calculator = GetProbabilityCalculator();

        // Act
        ProbabilityResult actual = Calculate(calculator, pA, pB);

        // Assert
        Assert.True(actual.IsSuccess);
        Assert.Equal(result, actual.Result);
        Assert.Null(actual.ValidationFailures);
    }

    [Fact]
    public void Calculate_Valid_LogsResult()
    {
        // Arrange
        ProbabilityCalculator calculator = GetProbabilityCalculator();

        // Act
        _ = Calculate(calculator, 0.5, 0.5);

        // Assert
        // TODO: Verify that the log message is correct
        A.CallTo(() => _logger.LogInformation(A<string>._)).MustHaveHappenedOnceExactly();
    }
}