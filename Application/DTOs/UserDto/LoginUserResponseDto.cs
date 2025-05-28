namespace Application.DTOs.UserDto;

public class LoginUserResponseDto
{
    public string Token { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
}