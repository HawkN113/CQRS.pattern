using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Commands;

public sealed class DeleteUserCommand : ICommand
{
    public DeleteUserCommand(int id)
    {
        UserId = id;
    }

    public int UserId { get; }
}