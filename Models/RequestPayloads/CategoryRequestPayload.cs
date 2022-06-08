using Models.Entities;

namespace Models.RequestPayloads;

/// <summary>
/// Request payload for <see cref="Category"/>.
/// </summary>
public class CategoryRequestPayload
{
    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string Title { get; set; } = default!;
}

