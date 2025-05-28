namespace Application.DTOs
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}