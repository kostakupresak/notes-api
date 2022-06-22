using Models.Entities;

namespace Models.ResponsePayloads;

/// <summary>
/// Response payload for <see cref="Category"/>.
/// </summary>
public class CategoryResponsePayload
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; init; } = default!;
}
