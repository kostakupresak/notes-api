using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

public class UserRepository : IUserRepository
{
    private const string validateQuery = "SELECT password FROM \"user\" " +
        "WHERE username = @Username AND deleted = FALSE;";
    private const string insertQuery = "INSERT INTO \"user\" " +
        "(username, \"password\") VALUES (@Username, @Password);";

    private readonly string _connectionString;

    /// <summary>
    /// Constructor for <see cref="UserRepository"/>.
    /// </summary>
    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }

    /// <inheritdoc cref="IUserRepository"/>
    public async Task<string> Validate(User user)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(validateQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Username", user.Username));
        command.Parameters.Add(new NpgsqlParameter("Password", user.Password));

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return reader.GetString(0);
        }

        throw new UnauthenticatedException();
    }

    /// <inheritdoc cref="IUserRepository"/>
    public async Task Add(User user)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(insertQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Username", user.Username));
        command.Parameters.Add(new NpgsqlParameter("Password", user.Password));

        var isAdded = await command.ExecuteNonQueryAsync() == 1;

        if (!isAdded)
        {
            throw new CouldNotSaveException();
        }
    }
}
