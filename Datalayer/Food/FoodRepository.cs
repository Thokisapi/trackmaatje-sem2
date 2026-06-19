using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Datalayer.Food;

public class FoodRepository
    : IFoodRepository
{
    private readonly string
        _connectionString;

    public FoodRepository(
        IConfiguration configuration)
    {
        _connectionString =
            configuration
                .GetConnectionString(
                    "DefaultConnection")
            ?? throw new
                InvalidOperationException(
                    "No connection string.");
    }

    public List<DbFood> GetFoods()
    {
        var foods =
            new List<DbFood>();

        using var connection =
            new MySqlConnection(
                _connectionString);

        connection.Open();

        var query = @"
            SELECT
                id,
                name,
                calories,
                carbs,
                protein,
                fat
            FROM food";

        using var cmd =
            new MySqlCommand(
                query,
                connection);

        using var reader =
            cmd.ExecuteReader();

        while (reader.Read())
        {
            foods.Add(
                new DbFood
                {
                    Id =
                        reader.GetInt32(
                            "id"),

                    Name =
                        reader.GetString(
                            "name"),

                    Calories =
                        reader.GetFloat(
                            "calories"),

                    Carbs =
                        reader.GetFloat(
                            "carbs"),

                    Protein =
                        reader.GetFloat(
                            "protein"),

                    Fat =
                        reader.GetFloat(
                            "fat")
                });
        }

        return foods;
    }
}