using AutoMapper;
using UserApi.Data;
using UserApi.Data.Models;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Commands.Handlers;

public sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
{
    private readonly AppContextInMemoryDb _dbContext;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(AppContextInMemoryDb dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task HandleAsync(UpdateUserCommand command)
    {
        var user = _mapper.Map<User>(command.Entity);
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}