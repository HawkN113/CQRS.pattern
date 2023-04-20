using UserApi.Interfaces;
using UserApi.Models;
#pragma warning disable CS1591

namespace UserApi.Commands;

public sealed class CreateUserCommand: ICommand
{
    public CreateUserCommand(UserDto newUser)
    {
        Entity = newUser;
    }

    public UserDto Entity { get; }
}