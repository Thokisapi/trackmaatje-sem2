namespace Datalayer.Users;

public interface IUserRepository
{
    void CreateUser(
        DbCreateUser user);

    DbUser? GetUserByEmail(
        string email);
}