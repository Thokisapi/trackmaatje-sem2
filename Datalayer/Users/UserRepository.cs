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
            var query = @"INSERT INTO user (name, email, password, role_id)
                                 VALUES (@name, @email, @password, @role_id)";

            var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@role_id", 2);

            cmd.ExecuteNonQuery();
        }
        public DbUser? GetUserByEmail(string email)
        {
            using var connection = new MySqlConnection(_connectionString);

            connection.Open();

            var query = @"SELECT id, name, email, password, role_id
                  FROM user
                  WHERE email = @email";

            using var cmd = new MySqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new DbUser
                {
                    Id = reader.GetInt32("id"),
                    Name = reader.GetString("name"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password"),
                    RoleId = reader.GetInt32("role_id")
                };
            }
            return null;
        }
    }
}