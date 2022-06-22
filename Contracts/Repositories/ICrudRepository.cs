namespace Contracts.Repositories;

/// <summary>
/// Contract for CRUD generic repository.
/// </summary>
/// <typeparam name="TEntity">Entity.</typeparam>
public interface ICrudRepository<TEntity>
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns><see cref="IEnumerable{TEntity}"/>.</returns>
    Task<IEnumerable<TEntity>> GetAll();

    /// <summary>
    /// Gets entity by id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="TEntity"/>.</returns>
    Task<TEntity> GetById(int id);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity"><see cref="TEntity"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Add(TEntity entity);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity"><see cref="TEntity"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Update(TEntity entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Delete(int id);
}
