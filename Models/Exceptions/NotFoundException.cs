using System.Runtime.Serialization;

namespace Models.Exceptions;

/// <summary>
/// Not found exception.
/// </summary>
[Serializable]
public class NotFoundException : CustomException
{
    private const int StatusCode = 404;
    private const string ErrorMessage = "Couldn't find entity.";
    
    /// <summary>
    /// Constructor for <see cref="NotFoundException"/>.
    /// </summary>
    public NotFoundException() : base(ErrorMessage)
    {
    }

    /// <summary>
    /// Constructor for <see cref="NotFoundException"/>.
    /// </summary>
    /// <param name="innerException"><see cref="Exception"/>.</param>
    public NotFoundException(Exception innerException): base(ErrorMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor for <see cref="NotFoundException"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/>.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
