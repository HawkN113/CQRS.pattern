using UserApi.Data;
#pragma warning disable CS1591

namespace UserApi.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void AddTestData(this WebApplication builder)
    {
        using var scope = builder.Services.CreateScope();
        var services = scope.ServiceProvider;
        DataGenerator.Initialize(services);
    }
}