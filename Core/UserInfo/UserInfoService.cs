namespace Core.UserInfo;

public class UserInfoService(
    MacroCalculator calculator)
    : IUserInfoService
{
    public MacroPlan Calculate(
        UserInfoRequest request)
    {
        return calculator.Calculate(request);
    }
}