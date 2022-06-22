using Microsoft.Extensions.Configuration;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

/// <summary>
/// Class for database manipulation.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public abstract class Repository<TEntity>
{
    private readonly string _connectionString;
    
    protected Repository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }
    
    protected async Task<IEnumerable<TEntity>> FindAll(string query)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(query, connection);
        await using var dataReader = await command.ExecuteReaderAsync();

        var entities = new List<TEntity>();

        while (await dataReader.ReadAsync())
        {
            entities.Add(MapToEntity(dataReader));
        }

        return entities;
    }

    protected async Task<TEntity> Filter<TException>(
        string query,
        IEnumerable<NpgsqlParameter> sqlParameters) where TException : CustomException, new()
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(sqlParameters.ToArray());

        await using var dataReader = await command.ExecuteReaderAsync();

        if (await dataReader.ReadAsync())
        {
            return MapToEntity(dataReader);
        }

        throw new TException();
    }

    protected async Task<TEntity> Filter(string query, IEnumerable<NpgsqlParameter> sqlParameters)
    {
        return await Filter<NotFoundException>(query, sqlParameters);
    }

    protected async Task Add(string query, IEnumerable<NpgsqlParameter> sqlParameters)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(sqlParameters.ToArray());

        var isAdded = await command.ExecuteNonQueryAsync() == 1;

        if (!isAdded)
        {
            throw new CouldNotSaveException();
        }
    }
    
    protected async Task Update(string query, IEnumerable<NpgsqlParameter> sqlParameters)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(sqlParameters.ToArray());

        var isUpdated = await command.ExecuteNonQueryAsync() == 1;

        if (!isUpdated)
        {
            throw new CouldNotSaveException();
        }
    }
    
    protected async Task Delete(string query, IEnumerable<NpgsqlParameter> sqlParameters)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddRange(sqlParameters.ToArray());

        var isDeleted = await command.ExecuteNonQueryAsync() == 1;

        if (!isDeleted)
        {
            throw new CouldNotDeleteException();
        }
    }

    protected abstract TEntity MapToEntity(NpgsqlDataReader dataReader);
}