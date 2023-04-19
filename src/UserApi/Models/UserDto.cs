#pragma warning disable CS8618
#pragma warning disable CS1591
namespace UserApi.Models;

public class UserDto
{
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public GenderDto Gender { get; set; }
    public bool Active { get; set; }
}

public enum GenderDto
{
    Female = 0,
    Male = 1,
    Unknown = 2
}