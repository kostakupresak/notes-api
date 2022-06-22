using Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using Models.Exceptions;
using Npgsql;

namespace DataAccess;

/// <summary>
/// Category repository.
/// </summary>
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private const string GetAllQuery =
        "SELECT id, title, deleted FROM category WHERE deleted = FALSE;";
    private const string GetByIdQuery =
        "SELECT id, title, deleted FROM category WHERE id = @Id;";
    private const string InsertQuery =
        "INSERT INTO category (title) VALUES (@Title);";
    private const string UpdateQuery =
        "UPDATE category SET title = @Title WHERE id = @Id;";
    private const string DeleteQuery =
        "UPDATE category SET deleted = TRUE WHERE id = @Id;";

    /// <summary>
    /// Constructor for <see cref="CategoryRepository"/>.
    /// </summary>
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await FindAll(GetAllQuery);
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task<Category> GetById(int id)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", id)
        };

        return await Filter(GetByIdQuery, sqlParameters);
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Add(Category entity)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Title", entity.Title)
        };

        await base.Add(InsertQuery, sqlParameters);
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Update(Category entity)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", entity.Id),
            new NpgsqlParameter("Title", entity.Title)
        };

        await base.Update(UpdateQuery, sqlParameters);
    }

    /// <inheritdoc cref="ICategoryRepository"/>
    public async Task Delete(int id)
    {
        var sqlParameters = new []
        {
            new NpgsqlParameter("Id", id),
        };

        await base.Delete(DeleteQuery, sqlParameters);
    }

    protected override Category MapToEntity(NpgsqlDataReader dataReader)
    {
        var id = dataReader.GetInt32(0);
        var title = dataReader.GetString(1);
        var isDeleted = dataReader.GetBoolean(2);

        return new Category
        {
            Id = id,
            Title = title,
            IsDeleted = isDeleted
        };
    }
}
