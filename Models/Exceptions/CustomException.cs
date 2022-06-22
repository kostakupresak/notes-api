using System.Runtime.Serialization;

namespace Models.Exceptions;

/// <summary>
/// Custom exception.
/// </summary>
[Serializable]
public abstract class CustomException : Exception
{
    /// <summary>
    /// Constructor for <see cref="CustomException"/>.
    /// </summary>
    protected CustomException()
    {
    }
    
    /// <summary>
    /// Constructor for <see cref="CustomException"/>.
    /// </summary>
    /// <param name="message">Message.</param>
    protected CustomException(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CustomException"/>.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="innerException"><see cref="Exception"/>.</param>
    protected CustomException(string message, Exception innerException): base(message, innerException)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CustomException"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/>.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    /// <summary>
    /// Gets HTTP status code.
    /// </summary>
    /// <returns>HTTP status code.</returns>
    public abstract int GetStatusCode();
}
