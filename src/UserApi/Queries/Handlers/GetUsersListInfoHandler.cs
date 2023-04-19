using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Queries.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Queries.Handlers;

public sealed class GetUsersListInfoHandler: IQueryHandler<GetUsersListInfo, IEnumerable<UserDto>>
{
    private readonly AppContextInMemoryDb _dbContext;
    private readonly IMapper _mapper;

    public GetUsersListInfoHandler(AppContextInMemoryDb dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> HandleAsync(GetUsersListInfo query)
    {
        var list = await _dbContext.Users.ToListAsync();
        return _mapper.Map<IEnumerable<UserDto>>(list);
    }
}