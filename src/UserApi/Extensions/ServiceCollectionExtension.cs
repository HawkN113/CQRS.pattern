using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Services;
using UserApi.Services.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataConfiguration(this IServiceCollection services)
    {
        services.AddDbContextPool<AppContextInMemoryDb>((provider, options) =>
        {
            options.UseInMemoryDatabase(databaseName: "AppDb");
        });
        return services;
    }
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}