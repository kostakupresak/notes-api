using System.Runtime.Serialization;

namespace Models.Exceptions;

/// <summary>
/// Could not save exception.
/// </summary>
[Serializable]
public class CouldNotSaveException : CustomException
{
    private const int StatusCode = 400;
    private const string ErrorMessage = "Couldn't save entity.";
    
    /// <summary>
    /// Constructor for <see cref="CouldNotSaveException"/>.
    /// </summary>
    public CouldNotSaveException() : base(ErrorMessage)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CouldNotSaveException"/>.
    /// </summary>
    /// <param name="innerException"><see cref="Exception"/>.</param>
    public CouldNotSaveException(Exception innerException): base(ErrorMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CouldNotSaveException"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/>.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected CouldNotSaveException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
