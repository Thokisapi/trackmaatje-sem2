namespace Core.UserInfo;

public class UserinfoData
{
    public int UserId { get; set; }
    public int Age { get; set; }
    public float Weight { get; set; }
    public required string Gender { get; set; } 
    public int Height { get; set; }
    public float GoalCalories { get; set; }
    public float GoalCarbs { get; set; }
    public float GoalProtein { get; set; }
    public float GoalFats { get; set; }
}