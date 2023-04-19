using Microsoft.EntityFrameworkCore;
using UserApi.Data.Interfaces;
using UserApi.Data.Models;
#pragma warning disable CS1591
#pragma warning disable CS8618

namespace UserApi.Data;

public class AppContextInMemoryDb: DbContext, IAppContextInMemoryDb
{
    public DbSet<User> Users { get; set; }
    public AppContextInMemoryDb(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
    }
}