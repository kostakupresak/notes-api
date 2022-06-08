using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

/// <summary>
/// Category repository.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private const string getAllQuery =
        "SELECT id, title, deleted FROM category WHERE deleted = FALSE;";
    private const string getByIdQuery =
        "SELECT title, deleted FROM category WHERE id = @Id;";
    private const string insertQuery =
        "INSERT INTO category (title) VALUES (@Title);";
    private const string updateQuery =
        "UPDATE category SET title = @Title WHERE id = @Id;";
    private const string deleteQuery =
        "UPDATE category SET deleted = TRUE WHERE id = @Id;";

    private readonly string _connectionString;

    /// <summary>
    /// Constructor for <see cref="CategoryRepository"/>.
    /// </summary>
    public CategoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task<IEnumerable<Category>> GetAll()
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(getAllQuery, connection);
        await using var reader = await command.ExecuteReaderAsync();

        var categories = new List<Category>();

        while (await reader.ReadAsync())
        {
            var id = reader.GetInt32(0);
            var title = reader.GetString(1);
            var isDeleted = reader.GetBoolean(2);

            categories.Add(new Category
            {
                Id = id,
                Title = title,
                IsDeleted = isDeleted
            });
        }

        return categories;
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task<Category> GetById(int id)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(getByIdQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Id", id));

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            var title = reader.GetString(0);
            var isDeleted = reader.GetBoolean(1);

            return new Category
            {
                Id = id,
                Title = title,
                IsDeleted = isDeleted
            };
        }

        throw new NotFoundException();
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Add(Category entity)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(insertQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Title", entity.Title));

        var isAdded = await command.ExecuteNonQueryAsync() == 1;

        if (!isAdded)
        {
            throw new CouldNotSaveException();
        }
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Update(Category entity)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(updateQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Id", entity.Id));
        command.Parameters.Add(new NpgsqlParameter("Title", entity.Title));

        var isUpdated = await command.ExecuteNonQueryAsync() == 1;

        if (!isUpdated)
        {
            throw new CouldNotSaveException();
        }
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Delete(int id)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(deleteQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Id", id));

        var isDeleted = await command.ExecuteNonQueryAsync() == 1;

        if (!isDeleted)
        {
            throw new CouldNotDeleteException();
        }
    }
}
