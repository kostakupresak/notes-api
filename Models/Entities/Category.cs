namespace Models.Entities;

/// <summary>
/// Category entity.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}

