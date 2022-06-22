using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

/// <summary>
/// Note repository.
/// </summary>
public class NoteRepository : Repository<Note>, INoteRepository
{
    private const string GetAllQuery =
        "SELECT note.id, note.title, content, last_updated, category_id, " +
        "category.title, note.deleted " +
        "FROM note INNER JOIN category ON category.id = category_id " +
        "WHERE note.deleted = FALSE;";
    private const string GetByIdQuery =
        "SELECT note.id, note.title, content, last_updated, category_id, " +
        "category.title, note.deleted " +
        "FROM note INNER JOIN category ON category.id = category_id " +
        "WHERE note.id = @Id;";
    private const string InsertQuery =
        "INSERT INTO note (title, content, category_id) " +
        "VALUES (@Title, @Content, @CategoryId);";
    private const string UpdateQuery =
        "UPDATE note SET title = @Title, content = @Content, " +
        "category_id = @CategoryId WHERE id = @Id;";
    private const string DeleteQuery =
        "UPDATE note SET deleted = TRUE WHERE id = @Id;";

    /// <summary>
    /// Constructor for <see cref="NoteRepository"/>.
    /// </summary>
    public NoteRepository(IConfiguration configuration) : base(configuration)
    {
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task<IEnumerable<Note>> GetAll()
    {
        return await FindAll(GetAllQuery);
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task<Note> GetById(int id)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", id)
        };

        return await Filter(GetByIdQuery, sqlParameters);
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task Add(Note entity)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Title", entity.Title),
            new NpgsqlParameter("Content", entity.Content),
            new NpgsqlParameter("CategoryId", entity.Category.Id)
        };

        await base.Add(InsertQuery, sqlParameters);
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task Update(Note entity)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", entity.Id),
            new NpgsqlParameter("Title", entity.Title),
            new NpgsqlParameter("Content", entity.Content),
            new NpgsqlParameter("CategoryId", entity.Category.Id)
        };

        await base.Update(UpdateQuery, sqlParameters);
    }

    /// <inheritdoc cref="INoteRepository"/>
    public async Task Delete(int id)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", id),
        };

        await base.Delete(DeleteQuery, sqlParameters);
    }

    protected override Note MapToEntity(NpgsqlDataReader dataReader)
    {
        var id = dataReader.GetInt32(0);
        var title = dataReader.GetString(1);
        var content = dataReader.GetString(2);
        var lastUpdated = dataReader.GetDateTime(3);
        var categoryId = dataReader.GetInt32(4);
        var categoryTitle = dataReader.GetString(5);
        var isDeleted = dataReader.GetBoolean(6);

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
}
