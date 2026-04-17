using Datalayer.Users;

namespace Core.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public void CreateUser(CreateUserRequest user)
    {
        var dbUser = new DbCreateUser(user.Name, user.Email, user.Password);
        userRepository.CreateUser(dbUser);
    }
}