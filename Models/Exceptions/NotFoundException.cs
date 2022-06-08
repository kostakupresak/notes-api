namespace Models.Exceptions;

/// <summary>
/// Not found exception.
/// </summary>
public class NotFoundException : Exception
{
    public const int StatusCode = 404;

    /// <summary>
    /// Constructor for <see cref="NotFoundException"/>.
    /// </summary>
    public NotFoundException() : base("Object isn't found.")
    {
    }
}
