using UserApi.Models;
#pragma warning disable CS1591

namespace UserApi.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetListAsync();
    Task<UserDto> GetByIdAsync(int userId);
    Task<UserDto> CreateAsync(UserDto entity);
    Task<int> UpdateAsync(UserDto entity);
    Task<int> DeleteAsync(int userId);
}