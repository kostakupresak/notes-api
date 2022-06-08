using Models.Entities;

namespace Contracts.Repositories;

/// <summary>
/// Contract for user repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Validates user in order to log it in.
    /// </summary>
    /// <param name="user"><see cref="User"/>.</param>
    /// <returns><see cref="Task{string}"/> as hashed password.</returns>
    Task<string> Validate(User user);

    /// <summary>
    /// Adds a new user.
    /// </summary>
    /// <param name="user"><see cref="User"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Add(User user);
}
