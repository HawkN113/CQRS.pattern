using UserApi.Queries.Interfaces;

#pragma warning disable CS1591
namespace UserApi.Queries;

public class GetUserByIdInfo: IQuery
{
    public GetUserByIdInfo(int userId)
    {
        Id = userId;
    }
    public int Id { get; }
}