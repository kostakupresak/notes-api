using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

/// <summary>
/// Note repository.
/// </summary>
public class NoteRepository : INoteRepository
{
    private const string getAllQuery =
        "SELECT note.id, note.title, content, last_updated, category_id, " +
        "category.title, note.deleted " +
        "FROM note INNER JOIN category ON category.id = category_id " +
        "WHERE note.deleted = FALSE;";
    private const string getByIdQuery =
        "SELECT note.title, content, last_updated, category_id, " +
        "category.title, note.deleted " +
        "FROM note INNER JOIN category ON category.id = category_id " +
        "WHERE note.id = @Id;";
    private const string insertQuery =
        "INSERT INTO note (title, content, category_id) " +
        "VALUES (@Title, @Content, @CategoryId);";
    private const string updateQuery =
        "UPDATE note SET title = @Title, content = @Content, " +
        "category_id = @CategoryId WHERE id = @Id;";
    private const string deleteQuery =
        "UPDATE note SET deleted = TRUE WHERE id = @Id;";

    private readonly string _connectionString;

    /// <summary>
    /// Constructor for <see cref="NoteRepository"/>.
    /// </summary>
    public NoteRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task<IEnumerable<Note>> GetAll()
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(getAllQuery, connection);
        await using var reader = await command.ExecuteReaderAsync();

        var notes = new List<Note>();

        while (await reader.ReadAsync())
        {
            var id = reader.GetInt32(0);
            var title = reader.GetString(1);
            var content = reader.GetString(2);
            var lastUpdated = reader.GetDateTime(3);
            var categoryId = reader.GetInt32(4);
            var categoryTitle = reader.GetString(5);
            var isDeleted = reader.GetBoolean(6);

            notes.Add(new Note
            {
                Id = id,
                Title = title,
                Content = content,
                LastUpdated = lastUpdated,
                Category = new Category
                {
                    Id = categoryId,
                    Title = categoryTitle
                },
                IsDeleted = isDeleted
            });
        }

        return notes;
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task<Note> GetById(int id)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(getByIdQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Id", id));

        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            var title = reader.GetString(0);
            var content = reader.GetString(1);
            var lastUpdated = reader.GetDateTime(2);
            var categoryId = reader.GetInt32(3);
            var categoryTitle = reader.GetString(4);
            var isDeleted = reader.GetBoolean(5);

            return new Note
            {
                Id = id,
                Title = title,
                Content = content,
                LastUpdated = lastUpdated,
                Category = new Category
                {
                    Id = categoryId,
                    Title = categoryTitle
                },
                IsDeleted = isDeleted
            };
        }

        throw new NotFoundException();
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task Add(Note entity)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(insertQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Title", entity.Title));
        command.Parameters.Add(new NpgsqlParameter("Content", entity.Content));
        command.Parameters.Add(
            new NpgsqlParameter("CategoryId", entity.Category.Id));

        var isAdded = await command.ExecuteNonQueryAsync() == 1;

        if (!isAdded)
        {
            throw new CouldNotSaveException();
        }
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task Update(Note entity)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(updateQuery, connection);
        command.Parameters.Add(new NpgsqlParameter("Id", entity.Id));
        command.Parameters.Add(new NpgsqlParameter("Title", entity.Title));
        command.Parameters.Add(new NpgsqlParameter("Content", entity.Content));
        command.Parameters.Add(
            new NpgsqlParameter("CategoryId", entity.Category.Id));

        var isUpdated = await command.ExecuteNonQueryAsync() == 1;

        if (!isUpdated)
        {
            throw new CouldNotSaveException();
        }
    }

    /// <inheritdoc cref="INoteRepository"/>
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
