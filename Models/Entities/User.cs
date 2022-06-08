namespace Models.Entities;

/// <summary>
/// User entity.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// Gets or sets password.
    /// </summary>
    public string Password { get; set; } = default!;

    /// <summary>
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}

