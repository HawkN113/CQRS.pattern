using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using UserApi.Commands;
using UserApi.Models;
using UserApi.Queries;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class UserController: ControllerBase
{
    private readonly IQueryHandler<GetUserByIdInfo, UserDto> _getUserByIdInfoHandler;
    private readonly IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>> _getUsersListInfoHandler;
    private readonly ICommandHandler<CreateUserCommand> _createUserCommandHandler;
    private readonly ICommandHandler<UpdateUserCommand> _updateUserCommandHandler;
    private readonly ICommandHandler<DeleteUserCommand> _deleteUserCommandHandler;
    public UserController(
        IQueryHandler<GetUserByIdInfo, UserDto> getUserByIdInfoHandler,
        IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>> getUsersListInfoHandler,
        ICommandHandler<CreateUserCommand> createUserCommandHandler,
        ICommandHandler<UpdateUserCommand> updateUserCommandHandler,
        ICommandHandler<DeleteUserCommand> deleteUserCommandHandler)
    {
        _getUserByIdInfoHandler = getUserByIdInfoHandler;
        _getUsersListInfoHandler = getUsersListInfoHandler;
        _createUserCommandHandler = createUserCommandHandler;
        _updateUserCommandHandler = updateUserCommandHandler;
        _deleteUserCommandHandler = deleteUserCommandHandler;
    }

    /// <summary>
    /// Get users from database (Read operation)
    /// </summary>
    /// <returns></returns>
    [HttpGet("getList")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    public async Task<IActionResult> GetUsersList()
    {
        var query = new GetUsersListInfo();
        var list = await _getUsersListInfoHandler.HandleAsync(query);
        return Ok(list);
    }
    
    /// <summary>
    /// Get user by id (Read operation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("getById")]
    [ProducesResponseType(typeof(UserDto), 200)]
    public async Task<IActionResult> GetUserById([FromQuery] int id)
    {
        var query = new GetUserByIdInfo(id);
        var result = await _getUserByIdInfoHandler.HandleAsync(query);
        return Ok(result);
    }

    /// <summary>
    /// Delete user from database (Write operation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    public async Task<IActionResult> DeleteUser([FromQuery] int id)
    {
        var command = new DeleteUserCommand(id);
        await _deleteUserCommandHandler.HandleAsync(command);
        return Ok();
    }

    /// <summary>
    /// Create a new user (Write operation)
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(UserDto), 201)]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        var command = new CreateUserCommand(user);
        await _createUserCommandHandler.HandleAsync(command);
        return Created("User has been created",null);
    }

    /// <summary>
    /// Updated user data (Write operation)
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut("update")]
    [ProducesResponseType(typeof(UserDto), 200)]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
    {
        var command = new UpdateUserCommand(user);
        await _updateUserCommandHandler.HandleAsync(command);
        return Ok();
    }
}