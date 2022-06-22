using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

public class UserRepository : Repository<User>, IUserRepository
{
    private const string ValidateQuery = "SELECT username, password FROM \"user\" " +
        "WHERE username = @Username AND deleted = FALSE;";
    private const string InsertQuery = "INSERT INTO \"user\" " +
        "(username, \"password\") VALUES (@Username, @Password);";

    /// <summary>
    /// Constructor for <see cref="UserRepository"/>.
    /// </summary>
    public UserRepository(IConfiguration configuration) : base(configuration)
    {
    }

    /// <inheritdoc cref="IUserRepository"/>
    public async Task<string> Validate(User user)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Username", user.Username),
            new NpgsqlParameter("Password", user.Password)
        };
        
        User foundUser = await Filter<UnauthenticatedException>(ValidateQuery, sqlParameters);
        
        return foundUser.Password;
    }

    /// <inheritdoc cref="IUserRepository"/>
    public async Task Add(User user)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Username", user.Username),
            new NpgsqlParameter("Password", user.Password)
        };

        await base.Add(InsertQuery, sqlParameters);
    }

    protected override User MapToEntity(NpgsqlDataReader dataReader)
    {
        var username = dataReader.GetString(0);
        var password = dataReader.GetString(1);

        return new User
        {
            Username = username,
            Password = password
        };
    }
}
