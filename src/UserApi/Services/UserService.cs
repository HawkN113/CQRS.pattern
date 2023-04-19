using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Data.Models;
using UserApi.Models;
using UserApi.Services.Interfaces;

namespace UserApi.Services;

internal class UserService : IUserService
{
    private readonly AppContextInMemoryDb _context;
    private readonly IMapper _mapper;

    public UserService(AppContextInMemoryDb context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateAsync(UserDto entity)
    {
        var user = _mapper.Map<User>(entity);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> UpdateAsync(UserDto entity)
    {
        var user = _mapper.Map<User>(entity);
        _context.Users.Update(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync();
    }
}