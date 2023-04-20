using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Interfaces;
#pragma warning disable CS1591

namespace UserApi.Queries.Handlers;

public sealed class GetUserByIdInfoHandler: IQueryHandler<GetUserByIdInfo, UserDto>
{
    private readonly AppContextInMemoryDb _dbContext;
    private readonly IMapper _mapper;

    public GetUserByIdInfoHandler(AppContextInMemoryDb dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<UserDto> HandleAsync(GetUserByIdInfo query)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == query.UserId);
        return _mapper.Map<UserDto>(user);
    }
}