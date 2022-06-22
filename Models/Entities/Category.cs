namespace Models.Entities;

/// <summary>
/// Category entity.
/// </summary>
public class Category
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
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; init; }
}

