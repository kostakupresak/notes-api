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
    public CategoryResponsePayload Category { get; init; } = default!;
}
