namespace Contracts.Services;

/// <summary>
/// Contract for CRUD generic service.
/// </summary>
/// <typeparam name="TRequestPayload">Request payload.</typeparam>
/// <typeparam name="TResponsePayload">Response payload.</typeparam>
public interface ICrudService<TRequestPayload, TResponsePayload>
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>
    /// <see cref="Task{IEnumerable{TResponsePayload}}"/>.
    /// </returns>
    Task<IEnumerable<TResponsePayload>> GetAll();

    /// <summary>
    /// Gets entity by id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task{TResponsePayload}"/>.</returns>
    Task<TResponsePayload> GetById(int id);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="requestPayload">
    /// <see cref="TRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    Task Add(TRequestPayload requestPayload);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="requestPayload">
    /// <see cref="TRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task"/>.</returns>
    Task Update(int id, TRequestPayload requestPayload);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Delete(int id);
}
