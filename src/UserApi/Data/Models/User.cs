#pragma warning disable CS8618
#pragma warning disable CS1591
namespace UserApi.Data.Models;

public class User
{
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender Gender { get; set; }
    public bool Active { get; set; }
}
public enum Gender
{
    Female,
    Male,
    Unknown
}