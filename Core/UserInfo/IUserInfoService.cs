namespace Core.UserInfo;

public interface IUserInfoService
{
    MacroPlan Calculate(UserInfoRequest request);
    void SaveUserInfo(SaveUserInfoRequest request);
}