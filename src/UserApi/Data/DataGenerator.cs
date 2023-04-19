using Microsoft.EntityFrameworkCore;
using UserApi.Data.Models;
// ReSharper disable UnusedType.Global

namespace UserApi.Data;

internal static class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppContextInMemoryDb(
            serviceProvider.GetRequiredService<DbContextOptions<AppContextInMemoryDb>>());
        var users = new List<User>()
        {
            new()
            {
                Id = 1,
                FirstName = "Christoph",
                LastName = "Waltz",
                Gender = Gender.Male,
                Active = true
            },
            new()
            {
                Id = 2,
                FirstName = "Sonja",
                LastName = "Kirchberger",
                Gender = Gender.Female,
                Email = "Sonja.Kirchberger@email.com",
                Active = false
            },
            new()
            {
                Id = 3,
                FirstName = "Grit",
                LastName = "Haid",
                Gender = Gender.Female,
                Email = "Grit.Haid@email.com",
                Active = false
            }
        };
        context.Users.AddRange(users);
        context.SaveChanges();
    }
}