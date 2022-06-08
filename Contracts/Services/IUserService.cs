using Models.RequestPayloads;
using Models.ResponsePayloads;

namespace Contracts.Services;

/// <summary>
/// Contract for user service.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Validates user in order to log it in.
    /// </summary>
    /// <param name="userRequestPayload">
    /// <see cref="UserRequestPayload"/>.
    /// </param>
    /// <returns><see cref="Task{TokenResponsePayload}"/>.</returns>
    Task<TokenResponsePayload> Validate(UserRequestPayload userRequestPayload);

    /// <summary>
    /// Adds a new user.
    /// </summary>
    /// <param name="userRequestPayload"><see cref="UserRequestPayload"/>.</param>
    /// <returns><see cref="Task"/>.</returns>
    Task Add(UserRequestPayload userRequestPayload);
}
