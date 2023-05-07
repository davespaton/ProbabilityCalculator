using Calculator.Probability.Models;
using Calculator.Probability.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Probability;
public static class ProbabilityServiceExtensions
{
    public static IServiceCollection AddProbabilityService(this IServiceCollection services)
    {
        services.AddScoped<IProbabilityCalculator, ProbabilityCalculator>();
        services.AddScoped<IProbabilityCalculatorFactory, ProbabilityCalculatorFactory>();

        services.AddScoped<IValidator<CalculateProbability>, CalculateProbabilityValidator>();

        return services;
    }
}
