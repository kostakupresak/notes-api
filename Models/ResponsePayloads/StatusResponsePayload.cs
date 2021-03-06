namespace Models.ResponsePayloads;

/// <summary>
/// Status class that describes API version.
/// </summary>
public class StatusResponsePayload
{
    /// <summary>
    /// Gets or sets version.
    /// </summary>
    public int Version { get; init; }

    /// <summary>
    /// Gets or sets description.
    /// </summary>
    public string Description { get; init; } = default!;
}
