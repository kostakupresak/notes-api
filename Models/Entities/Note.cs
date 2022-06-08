namespace Models.Entities;

/// <summary>
/// Note entity.
/// </summary>
public class Note
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
    /// Gets or sets content.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Gets or sets last updated date.
    /// </summary>
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets category.
    /// </summary>
    public Category Category { get; set; } = default!;

    /// <summary>
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
