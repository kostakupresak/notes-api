using Models.Entities;

namespace Models.RequestPayloads;

/// <summary>
/// Request payload for <see cref="User"/>.
/// </summary>
public class UserRequestPayload
{
    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// Gets or sets password.
    /// </summary>
    public string Password { get; set; } = default!;
}
