namespace Datalayer.UserInfo;

public interface IUserInfoRepository
{
    DbUserInfo? GetUserInfoByUserId(
        int userId);

    void SaveUserInfo(
        DbUserInfo userInfo);
}