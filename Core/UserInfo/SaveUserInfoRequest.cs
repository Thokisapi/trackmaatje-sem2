namespace Core.UserInfo;

public class SaveUserInfoRequest
{
    public int UserId { get; init; }

    public int Age { get; init; }

    public float Weight { get; init; }

    public string Gender { get; init; } = null!;

    public int Height { get; init; }

    public float GoalCalories { get; init; }

    public float GoalCarbs { get; init; }

    public float GoalProtein { get; init; }

    public float GoalFat { get; init; }
}