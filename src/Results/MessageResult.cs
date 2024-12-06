using System.Text.Json.Serialization;

namespace Tolitech.Results;

/// <summary>
/// Represents a message result with optional context, key, type, and message.
/// </summary>
public class MessageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageResult"/> class with the specified context name, key, type, and message.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the message.</param>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="type">The type of the message (Information, Warning, Error).</param>
    /// <param name="message">The message content.</param>
    protected MessageResult(string? contextName, string? key, MessageType type, string message)
    {
        ContextName = contextName;
        Key = key;
        Type = type;
        Message = message;
    }

    /// <summary>
    /// Gets the name of the context associated with the message.
    /// </summary>
    public string? ContextName { get; }

    /// <summary>
    /// Gets an optional key associated with the message.
    /// </summary>
    public string? Key { get; }

    /// <summary>
    /// Gets the type of the message (Information, Warning, Error).
    /// </summary>
    [JsonIgnore]
    public MessageType Type { get; }

    /// <summary>
    /// Gets the message content.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an informational type and the specified message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Information(string message)
    {
        return new(null, null, MessageType.Information, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an informational type, optional key, and the specified message.
    /// </summary>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Information(string? key, string message)
    {
        return new(null, key, MessageType.Information, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an informational type, optional context name, key, and the specified message.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the message.</param>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Information(string? contextName, string? key, string message)
    {
        return new(contextName, key, MessageType.Information, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with a warning type and the specified message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Warning(string message)
    {
        return new(null, null, MessageType.Warning, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with a warning type, optional key, and the specified message.
    /// </summary>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Warning(string? key, string message)
    {
        return new(null, key, MessageType.Warning, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with a warning type, optional context name, key, and the specified message.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the message.</param>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static MessageResult Warning(string? contextName, string? key, string message)
    {
        return new(contextName, key, MessageType.Warning, message);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an error type and the specified message.
    /// </summary>
    /// <param name="message">The message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static ErrorResult Error(string message, Exception? exception = null)
    {
        return ErrorResult.Create(message, exception);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an error type, optional key, and the specified message.
    /// </summary>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static ErrorResult Error(string? key, string message, Exception? exception = null)
    {
        return ErrorResult.Create(key, message, exception);
    }

    /// <summary>
    /// Creates a new instance of <see cref="MessageResult"/> with an error type, optional context name, key, and the specified message.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the message.</param>
    /// <param name="key">An optional key associated with the message.</param>
    /// <param name="message">The message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="MessageResult"/>.</returns>
    public static ErrorResult Error(string? contextName, string? key, string message, Exception? exception = null)
    {
        return ErrorResult.Create(contextName, key, message, exception);
    }
}