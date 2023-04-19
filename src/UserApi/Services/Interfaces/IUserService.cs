using UserApi.Models;
#pragma warning disable CS1591

namespace UserApi.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateAsync(UserDto entity);
    Task<int> UpdateAsync(UserDto entity);
    Task<int> DeleteAsync(int userId);
}