namespace Tolitech.Results;

/// <summary>
/// Represents the type of message associated with a <see cref="MessageResult"/>.
/// </summary>
public enum MessageType
{
    /// <summary>
    /// Indicates an informational message (1).
    /// </summary>
    Information = 1,

    /// <summary>
    /// Indicates a warning message (2).
    /// </summary>
    Warning = 2,

    /// <summary>
    /// Indicates an error message (3).
    /// </summary>
    Error = 3,
}