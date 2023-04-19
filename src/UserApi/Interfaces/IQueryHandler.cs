#pragma warning disable CS1591
namespace UserApi.Interfaces;

/// <summary>
/// Used to mark query handler (process query)
/// </summary>
public interface IQueryHandler
{}

/// <summary>
/// Generic class to implement query handler
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TR"></typeparam>
public interface IQueryHandler<in T, TR> : IQueryHandler where T : IQuery
{
    Task<TR> HandleAsync(T query);
}