using FakeItEasy;
using FakeItEasy.Configuration;
using Microsoft.Extensions.Logging;

namespace Calculator.Probability.Tests;

public static class LogHelper
{
    public static IAnyCallConfigurationWithNoReturnTypeSpecified AssertLog<T>(this ILogger<T> logger, LogLevel logLevel = LogLevel.Information) => 
        A.CallTo(logger).Where(call => call.Method.Name == "Log" && call.GetArgument<LogLevel>(0) == logLevel);
}