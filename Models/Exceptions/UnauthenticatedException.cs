namespace Models.Exceptions;

/// <summary>
/// Unauthenticated exception.
/// </summary>
public class UnauthenticatedException : CustomException
{
    public const int StatusCode = 401;

    /// <summary>
    /// Constructor for <see cref="UnauthenticatedException"/>.
    /// </summary>
    public UnauthenticatedException()
        : base("User's credentials are incorrect.")
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
