namespace Tolitech.Results;

/// <summary>
/// Represents an error message with optional key and message.
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorMessage"/> class with the specified context  key and message.
    /// </summary>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    protected ErrorMessage(string? key, string message)
    {
        Key = key;
        Message = message;
    }

    /// <summary>
    /// Gets an optional key associated with the message.
    /// </summary>
    public string? Key { get; }

    /// <summary>
    /// Gets the message content.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ErrorMessage"/> with an error type and the specified message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="ErrorMessage"/>.</returns>
    public static ErrorMessage Create(string message)
    {
        return new ErrorMessage(null, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ErrorMessage"/> with an error type, optional key, and the specified message.
    /// </summary>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="ErrorMessage"/>.</returns>
    public static ErrorMessage Create(string? key, string message)
    {
        return new ErrorMessage(key, message);
    }
}