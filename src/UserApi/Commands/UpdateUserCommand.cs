using UserApi.Interfaces;
using UserApi.Models;
#pragma warning disable CS1591

namespace UserApi.Commands;

public sealed class UpdateUserCommand: ICommand
{
    public UpdateUserCommand(UserDto user)
    {
        Entity = user;
    }

    public UserDto Entity { get; }
}