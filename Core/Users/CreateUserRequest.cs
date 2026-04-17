namespace Core.Users;

public class CreateUserRequest(string name, string email, string password)
{
    public string Name { get; } = name;
    public string Email { get; } = email;
    public string Password { get; } = password;
}