using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Datalayer.UserInfo;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly string
        _connectionString;

    public UserInfoRepository(
        IConfiguration configuration)
    {
        _connectionString =
            configuration
                .GetConnectionString(
                    "DefaultConnection")
            ?? throw new
                InvalidOperationException(
                    "No connection string configured.");
    }

    public DbUserInfo?
        GetUserInfoByUserId(
            int userId)
    {
        using var connection =
            new MySqlConnection(
                _connectionString);

        connection.Open();

        var query = @"
            SELECT
                user_id,
                age,
                weight,
                gender,
                height,
                goalCalories,
                goalCarbs,
                goalProtein,
                goalFat
            FROM userinfo
            WHERE user_id =
                @userId";

        using var cmd =
            new MySqlCommand(
                query,
                connection);

        cmd.Parameters
            .AddWithValue(
                "@userId",
                userId);

        using var reader =
            cmd.ExecuteReader();

        if (!reader.Read())
            return null;

        return new DbUserInfo
        {
            UserId =
                reader.GetInt32(
                    "user_id"),

            Age =
                reader.GetInt32(
                    "age"),

            Weight =
                reader.GetFloat(
                    "weight"),

            Gender =
                reader.GetString(
                    "gender"),

            Height =
                reader.GetInt32(
                    "height"),

            GoalCalories =
                reader.GetFloat(
                    "goalCalories"),

            GoalCarbs =
                reader.GetFloat(
                    "goalCarbs"),

            GoalProtein =
                reader.GetFloat(
                    "goalProtein"),

            GoalFat =
                reader.GetFloat(
                    "goalFat")
        };
    }
    public void SaveUserInfo(
        DbUserInfo userInfo)
    {
        using var connection =
            new MySqlConnection(
                _connectionString);

        connection.Open();

        var query = @"
        INSERT INTO userinfo
        (
            user_id,
            age,
            weight,
            gender,
            height,
            goalCalories,
            goalCarbs,
            goalProtein,
            goalFat
        )
        VALUES
        (
            @user_id,
            @age,
            @weight,
            @gender,
            @height,
            @goalCalories,
            @goalCarbs,
            @goalProtein,
            @goalFat
        )";

        using var cmd =
            new MySqlCommand(
                query,
                connection);

        cmd.Parameters.AddWithValue(
            "@user_id",
            userInfo.UserId);

        cmd.Parameters.AddWithValue(
            "@age",
            userInfo.Age);

        cmd.Parameters.AddWithValue(
            "@weight",
            userInfo.Weight);

        cmd.Parameters.AddWithValue(
            "@gender",
            userInfo.Gender);

        cmd.Parameters.AddWithValue(
            "@height",
            userInfo.Height);

        cmd.Parameters.AddWithValue(
            "@goalCalories",
            userInfo.GoalCalories);

        cmd.Parameters.AddWithValue(
            "@goalCarbs",
            userInfo.GoalCarbs);

        cmd.Parameters.AddWithValue(
            "@goalProtein",
            userInfo.GoalProtein);

        cmd.Parameters.AddWithValue(
            "@goalFat",
            userInfo.GoalFat);

        cmd.ExecuteNonQuery();
    }
}