using System.Runtime.Serialization;

namespace Models.Exceptions;

/// <summary>
/// Unauthenticated exception.
/// </summary>
[Serializable]
public class UnauthenticatedException : CustomException
{
    public const int StatusCode = 401;
    private const string ErrorMessage = "Couldn't authenticate user.";
    
    /// <summary>
    /// Constructor for <see cref="UnauthenticatedException"/>.
    /// </summary>
    public UnauthenticatedException() : base(ErrorMessage)
    {
    }

    /// <summary>
    /// Constructor for <see cref="UnauthenticatedException"/>.
    /// </summary>
    /// <param name="innerException"><see cref="Exception"/>.</param>
    public UnauthenticatedException(Exception innerException): base(ErrorMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor for <see cref="UnauthenticatedException"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/>.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected UnauthenticatedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
