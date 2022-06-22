namespace Models.ResponsePayloads;

/// <summary>
/// Response payload for token.
/// </summary>
public class TokenResponsePayload
{
    /// <summary>
    /// Gets or sets token.
    /// </summary>
    public string Token { get; init; } = default!;
}
