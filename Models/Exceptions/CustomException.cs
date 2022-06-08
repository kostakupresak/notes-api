namespace Models.Exceptions;

/// <summary>
/// Custom exception.
/// </summary>
public abstract class CustomException : Exception
{
    /// <summary>
    /// Constructor for <see cref="CustomException"/>.
    /// </summary>
    /// <param name="message">Message.</param>
    protected CustomException(string message) : base(message)
    {
    }

    public abstract int GetStatusCode();
}
