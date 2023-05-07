using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Probability;
public static class ProbabilityServiceExtensions
{
    public static IServiceCollection AddProbabilityService(this IServiceCollection services)
    {
        services.AddScoped<IProbabilityCalculator, ProbabilityCalculator>();
        services.AddScoped<IProbabilityCalculatorFactory, ProbabilityCalculatorFactory>();

        return services;
    }
}
