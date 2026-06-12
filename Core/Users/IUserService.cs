namespace Core.Users;

public interface IUserService
{
    void CreateUser(CreateUserRequest user);
    User? Login(LoginUserRequest request);
}