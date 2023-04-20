using UserApi.Interfaces;

#pragma warning disable CS1591
namespace UserApi.Queries;

public class GetUserByIdInfo: IQuery
{
    public GetUserByIdInfo(int userId)
    {
        UserId = userId;
    }
    public int UserId { get; }
}