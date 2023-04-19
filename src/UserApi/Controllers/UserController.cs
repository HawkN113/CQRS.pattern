using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Queries;
using UserApi.Interfaces;
using UserApi.Services.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IQueryHandler<GetUserByIdInfo, UserDto> _getUserByIdInfoHandler;
    private readonly IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>> _getUsersListInfoHandler;
    public UserController(
        IUserService userService, 
        IQueryHandler<GetUserByIdInfo, UserDto> getUserByIdInfoHandler,
        IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>> getUsersListInfoHandler)
    {
        _userService = userService;
        _getUserByIdInfoHandler = getUserByIdInfoHandler;
        _getUsersListInfoHandler = getUsersListInfoHandler;
    }

    /// <summary>
    /// Get users from database
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
    /// Get user by id
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
    /// Delete user from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
    public async Task<IActionResult> DeleteUser([FromQuery] int id)
    {
        await _userService.DeleteAsync(id);
        return Ok();
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(UserDto), 201)]
    public async Task<IActionResult> CreateUser([FromBody] UserDto user)
    {
        var result = await _userService.CreateAsync(user);
        return Created("User has been created", result);
    }

    /// <summary>
    /// Updated user data
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPut("update")]
    [ProducesResponseType(typeof(UserDto), 200)]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
    {
        await _userService.UpdateAsync(user);
        return Ok();
    }
}