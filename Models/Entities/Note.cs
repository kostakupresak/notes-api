namespace Models.Entities;

/// <summary>
/// Note entity.
/// </summary>
public class Note
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; init; } = default!;

    /// <summary>
    /// Gets or sets content.
    /// </summary>
    public string Content { get; init; } = default!;

    /// <summary>
    /// Gets or sets last updated date.
    /// </summary>
    public DateTime LastUpdated { get; init; } = DateTime.Now;

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public Category Category { get; init; } = default!;

    /// <summary>
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; init; }
}
