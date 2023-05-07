using Calculator.Probability;
using Calculator.Probability.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProbabilityController : ControllerBase
{
    private readonly IProbabilityCalculator _probabilityCalculator;

    public ProbabilityController(IProbabilityCalculator probabilityCalculator)
    {
        _probabilityCalculator = probabilityCalculator;
    }

    [HttpGet("either")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Either(double pA, double pB)
    {
        ProbabilityResult result = _probabilityCalculator.Calculate(new CalculateProbability(ProbabilityType.Either, new[]{pA, pB}));
        return ProbabilityActionResult(result);
    }

    [HttpGet("combined-with")]
    [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CombinedWith(double pA, double pB)
    {
        ProbabilityResult result = _probabilityCalculator.Calculate(new CalculateProbability(ProbabilityType.CombinedWith, new[] { pA, pB }));
        return ProbabilityActionResult(result);
    }

    private IActionResult ProbabilityActionResult(ProbabilityResult result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Result);
        }

        Dictionary<string, string[]> errors = result.ValidationFailures!
            .GroupBy(g => g.PropertyName)
            .ToDictionary(
                grouping => grouping.Key, 
                grouping => grouping.Select(s => s.ErrorMessage).ToArray());

        var problems = new ValidationProblemDetails(errors);

        return BadRequest(problems);
    }
}