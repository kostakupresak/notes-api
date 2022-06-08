namespace Models.Exceptions;

/// <summary>
/// Could not delete exception.
/// </summary>
public class CouldNotDeleteException : CustomException
{
    public const int StatusCode = 400;

    /// <summary>
    /// Constructor for <see cref="CouldNotDeleteException"/>.
    /// </summary>
    public CouldNotDeleteException() : base("Object couldn't be deleted.")
    {
    }

    public override int GetStatusCode()
    {
        return StatusCode;
    }
}
