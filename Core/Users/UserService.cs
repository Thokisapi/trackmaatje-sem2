using Datalayer.Users;

namespace Core.Users;

public class UserService(IUserRepository userRepository) : IUserService
{

    public void CreateUser(CreateUserRequest user)
    {
        var dbUser = new DbCreateUser(user.Name, user.Email, user.Password);
        userRepository.CreateUser(dbUser);
    }
    public User? Login(LoginUserRequest request)
    {
        var dbUser = userRepository.GetUserByEmail(request.Email);

        if (dbUser == null)
            return null;

        if (dbUser.Password != request.Password)
            return null;

        return new User
        {
            Id = dbUser.Id,
            Name = dbUser.Name,
            Email = dbUser.Email,
            Password = dbUser.Password,
            RoleId = dbUser.RoleId
        };
    }
    public User? GetUserByEmail(
        string email)
    {
        var dbUser =
            userRepository.GetUserByEmail(
                email);

        if (dbUser == null)
            return null;

        return new User
        {
            Id = dbUser.Id,
            Name = dbUser.Name,
            Email = dbUser.Email,
            Password = dbUser.Password,
            RoleId = dbUser.RoleId
        };
    }
}