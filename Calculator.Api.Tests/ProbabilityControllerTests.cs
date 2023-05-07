using Calculator.Api.Controllers;
using Calculator.Probability;
using Calculator.Probability.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Tests;
public class ProbabilityControllerTests
{
    private readonly IProbabilityCalculator _fakeCalculator;

    public ProbabilityControllerTests()
    {
        _fakeCalculator = A.Fake<IProbabilityCalculator>();
    }

    ProbabilityController GetController() => new(_fakeCalculator);

    [Fact]
    public void Either_Valid_ReturnsCalculateResponse()
    {
        // Arrange
        ProbabilityController controller = GetController();
        const double expectedResult = 0.5;
        A.CallTo(() => _fakeCalculator.Calculate(A<CalculateProbability>._)).Returns(new ProbabilityResult(expectedResult));

        // Act
        IActionResult actual = controller.Either(0.1, 0.2);

        // Assert
        Assert.IsType<OkObjectResult>(actual);
        CalculateProbabilityResponse result = (CalculateProbabilityResponse)((OkObjectResult)actual).Value!;
        Assert.Equal(expectedResult, result.Probability);
    }

    [Fact]
    public void Either_Invalid_ReturnsBadRequest()
    {
        // Arrange
        ProbabilityController controller = GetController();
        const string expectedError = "Invalid probabilities";
        A.CallTo(() => _fakeCalculator.Calculate(A<CalculateProbability>._)).Returns(new ProbabilityResult(new[]
        {
            new FluentValidation.Results.ValidationFailure("Probabilities", expectedError)
        }));

        // Act
        IActionResult actual = controller.Either(0.1, 0.2);

        // Assert
        Assert.IsType<BadRequestObjectResult>(actual);
        ValidationProblemDetails result = (ValidationProblemDetails)((BadRequestObjectResult)actual).Value!;
        Assert.Equal(expectedError, result.Errors["Probabilities"].Single());
    }
}
