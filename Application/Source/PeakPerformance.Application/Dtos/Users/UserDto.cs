namespace PeakPerformance.Application.Dtos.Users;

public class UserDto
{
    public string FullName { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string ProfilePictureUrl { get; set; }
}