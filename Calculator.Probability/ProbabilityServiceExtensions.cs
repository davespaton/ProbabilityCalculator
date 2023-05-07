using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Probability;
public static class ProbabilityServiceExtensions
{
    public static IServiceCollection AddProbabilityService(this IServiceCollection services)
    {
        services.AddScoped<IProbabilityCalculator, ProbabilityCalculator>();

        return services;
    }
}
