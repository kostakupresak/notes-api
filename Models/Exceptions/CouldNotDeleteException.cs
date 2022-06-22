using System.Runtime.Serialization;

namespace Models.Exceptions;

/// <summary>
/// Could not delete exception.
/// </summary>
[Serializable]
public class CouldNotDeleteException : CustomException
{
    private const int StatusCode = 400;
    private const string ErrorMessage = "Couldn't delete entity.";
    
    /// <summary>
    /// Constructor for <see cref="CouldNotDeleteException"/>.
    /// </summary>
    public CouldNotDeleteException() : base(ErrorMessage)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CouldNotDeleteException"/>.
    /// </summary>
    /// <param name="innerException"><see cref="Exception"/>.</param>
    public CouldNotDeleteException(Exception innerException): base(ErrorMessage, innerException)
    {
    }

    /// <summary>
    /// Constructor for <see cref="CouldNotDeleteException"/>.
    /// </summary>
    /// <param name="info"><see cref="SerializationInfo"/>.</param>
    /// <param name="context"><see cref="StreamingContext"/>.</param>
    protected CouldNotDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
