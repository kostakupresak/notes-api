using System.Text.Json;

namespace Models.ResponsePayloads;

/// <summary>
/// Response payload for error.
/// </summary>
public class ErrorResponsePayload
{
    /// <summary>
    /// Gets or sets message.
    /// </summary>
    public string Message { get; init; } = default!;

    /// <summary>
    /// Converts to JSON string.
    /// </summary>
    /// <returns>JSON string.</returns>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
