using Calculator.Probability;
using Serilog;
using Serilog.Filters;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddProbabilityService();

    builder.Host.UseSerilog();
}

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(Matching.FromSource<IProbabilityCalculator>())
        .ReadFrom.Configuration(builder.Configuration, "CalculatorLog")
    )
    .CreateLogger();


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.UseCors(policyBuilder =>
    {
        policyBuilder
            .WithOrigins("http://localhost:3000")
            .WithMethods("GET")
            .WithHeaders("Accept", "application/json");
    });
}

try
{
    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}