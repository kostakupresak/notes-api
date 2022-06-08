﻿namespace Models.Exceptions;

/// <summary>
/// Could not save exception.
/// </summary>
public class CouldNotSaveException : Exception
{
    public const int StatusCode = 400;

    /// <summary>
    /// Constructor for <see cref="CouldNotSaveException"/>.
    /// </summary>
    public CouldNotSaveException() : base("Object couldn't be saved.")
    {
    }
}
