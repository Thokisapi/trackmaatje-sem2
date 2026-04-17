using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Datalayer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("No connection string configured for DefaultConnection.");
        }

        public void CreateUser(DbCreateUser user)
        {
            using var connection = new MySqlConnection(_connectionString);

            connection.Open();
            var query = @"INSERT INTO users (name, email, password, role_id)
                                 VALUES (@name, @email, @password, @role_id)";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role_id", 2);

            cmd.ExecuteNonQuery();
        }
    }
}