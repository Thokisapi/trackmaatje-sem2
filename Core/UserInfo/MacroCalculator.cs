namespace Core.UserInfo;

public class MacroCalculator
{
    public MacroPlan Calculate(UserInfoRequest request)
    {
        double bmr;

        if (request.Gender == "male")
        {
            bmr = (10 * request.Weight) + (request.Height) - (request.Age) + 5;
            
        }
        else
        {
            bmr = (10 * request.Weight) + (request.Height) - (request.Age) - 161;
        }
        double activityMultiplier = request.ActivityLevel switch
        {
            "sedentary" => 1.2,
            "lightly_active" => 1.375,
            "moderately_active" => 1.55,
            "very_active" => 1.725,
            "extra_active" => 1.9,
            _ => throw new ArgumentException("Invalid activity level")
        };
        var calories = bmr * activityMultiplier;
        calories = request.Goal switch
        {
            "weight_loss" => calories - 400,
            "weight_gain" => calories + 300,
            "maintenance" => calories,
            _ => throw new ArgumentException("Invalid goal")
        };
        var protein = (int)(request.Weight * 2.0);
        var fat = (int)(request.Weight * 0.8);
        var carbs = (int)((calories - (protein * 4) - (fat * 9)) / 4);
        return new MacroPlan
        {
            Calories = (int)calories,
            Carbs = carbs,
            Fats = fat,
            Proteins = protein
        };
    }
}