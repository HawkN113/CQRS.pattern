using Microsoft.EntityFrameworkCore;
using UserApi.Commands;
using UserApi.Commands.Handlers;
using UserApi.Data;
using UserApi.Models;
using UserApi.Queries;
using UserApi.Queries.Handlers;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataConfiguration(this IServiceCollection services)
    {
        services.AddDbContextPool<AppContextInMemoryDb>((_, options) =>
        {
            options.UseInMemoryDatabase(databaseName: "AppDb");
        });
        return services;
    }
    
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        #region Queries

        services.AddScoped<IQueryHandler<GetUserByIdInfo, UserDto>, GetUserByIdInfoHandler>();
        services.AddScoped<IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>>, GetUsersListInfoHandler>();

        #endregion

        #region Commands

        services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();

        #endregion

        return services;
    }
}