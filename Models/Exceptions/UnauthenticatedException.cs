namespace Models.Exceptions;

/// <summary>
/// Unauthenticated exception.
/// </summary>
public class UnauthenticatedException : Exception
{
    public const int StatusCode = 401;

    /// <summary>
    /// Constructor for <see cref="UnauthenticatedException"/>.
    /// </summary>
    public UnauthenticatedException()
        : base("User's credentials are incorrect.")
    {
    }
}
