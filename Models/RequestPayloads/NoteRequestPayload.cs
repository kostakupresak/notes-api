using Models.Entities;

namespace Models.RequestPayloads;

/// <summary>
/// Request payload for <see cref="Note"/>.
/// </summary>
public class NoteRequestPayload
{
    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Gets or sets content.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Gets or sets category id.
    /// </summary>
    public int CategoryId { get; set; }
}
