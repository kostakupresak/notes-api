namespace Models.Entities;

/// <summary>
/// User entity.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string Username { get; init; } = default!;

    /// <summary>
    /// Gets or sets password.
    /// </summary>
    public string Password { get; init; } = default!;
}

