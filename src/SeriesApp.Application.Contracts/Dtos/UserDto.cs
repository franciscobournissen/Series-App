using System;

namespace SeriesApp.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string ProfilePicture { get; set; }
    public bool IsAdmin { get; set; }
}