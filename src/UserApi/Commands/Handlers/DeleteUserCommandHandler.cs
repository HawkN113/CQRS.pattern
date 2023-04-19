using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Commands.Handlers;

public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly AppContextInMemoryDb _dbContext;

    public DeleteUserCommandHandler(AppContextInMemoryDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task HandleAsync(DeleteUserCommand command)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == command.UserId);
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}