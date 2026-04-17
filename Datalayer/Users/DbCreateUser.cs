namespace Datalayer.Users;

public class DbCreateUser(string name, string email, string password)
{
    public string Name { get; } = name;
    public string Email { get; } = email;
    public string Password { get; } = password;
}