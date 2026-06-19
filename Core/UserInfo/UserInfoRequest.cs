namespace Core.UserInfo;

public class UserInfoRequest(
    float weight,
    int height,
    int age,
    string gender,
    string activityLevel,
    string goal)
{
    public float Weight { get; } = weight;
    public int Height { get; } = height;
    public int Age { get; } = age;
    public string Gender { get; } = gender;
    public string ActivityLevel { get; } = activityLevel;
    public string Goal { get; } = goal;
}