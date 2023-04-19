using AutoMapper;
using UserApi.Data;
using UserApi.Data.Models;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Commands.Handlers;

public sealed class CreateUserCommandHandler: ICommandHandler<CreateUserCommand>
{
    private readonly AppContextInMemoryDb _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(AppContextInMemoryDb dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task HandleAsync(CreateUserCommand command)
    {
        var user = _mapper.Map<User>(command.Entity);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }
}