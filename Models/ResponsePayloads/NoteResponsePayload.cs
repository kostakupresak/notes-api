using Models.Entities;

namespace Models.ResponsePayloads;

/// <summary>
/// Response payload for <see cref="Note"/>.
/// </summary>
public class NoteResponsePayload
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
    public CategoryResponsePayload Category { get; set; } = default!;
}
