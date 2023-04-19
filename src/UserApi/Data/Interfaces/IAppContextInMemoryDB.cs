using Microsoft.EntityFrameworkCore;
using UserApi.Data.Models;
#pragma warning disable CS1591

namespace UserApi.Data.Interfaces;

public interface IAppContextInMemoryDb
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}