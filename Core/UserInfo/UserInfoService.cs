using Datalayer.UserInfo;

namespace Core.UserInfo;

public class UserInfoService(MacroCalculator calculator,    IUserInfoRepository userInfoRepository)  : IUserInfoService

{
    public MacroPlan Calculate(
        UserInfoRequest request)
    {
        return calculator.Calculate(request);
    }

    public void SaveUserInfo(
        SaveUserInfoRequest request)
    {
        var dbUserInfo =
            new DbUserInfo
            {
                UserId = request.UserId,
                Age = request.Age,
                Weight = request.Weight,
                Gender = request.Gender,
                Height = request.Height,
                GoalCalories = request.GoalCalories,
                GoalCarbs = request.GoalCarbs,
                GoalProtein = request.GoalProtein,
                GoalFat = request.GoalFat
            };

        userInfoRepository.SaveUserInfo(
            dbUserInfo);
    }
}