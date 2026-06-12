namespace Core.Users;

public class LoginUserRequest(
    string email,
    string password)
{
    public string Email { get; } = email;
    public string Password { get; } = password;
}