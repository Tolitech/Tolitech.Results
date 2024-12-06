namespace Tolitech.Results;

/// <summary>
/// Represents an error message result with optional context, key, message, and exception details.
/// </summary>
public sealed class ErrorResult : MessageResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorResult"/> class with the specified context name, key, message, and exception.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the error.</param>
    /// <param name="key">An optional key associated with the error.</param>
    /// <param name="message">The error message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    private ErrorResult(string? contextName, string? key, string message, Exception? exception = null)
        : base(contextName, key, MessageType.Error, message)
    {
        Exception = exception;
    }

    /// <summary>
    /// Gets the exception associated with the error.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ErrorResult"/> with the specified error message and optional exception details.
    /// </summary>
    /// <param name="message">The error message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="ErrorResult"/>.</returns>
    internal static ErrorResult Create(string message, Exception? exception = null)
    {
        return new(null, null, message, exception);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ErrorResult"/> with the specified error key, message, and optional exception details.
    /// </summary>
    /// <param name="key">An optional key associated with the error.</param>
    /// <param name="message">The error message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="ErrorResult"/>.</returns>
    internal static ErrorResult Create(string? key, string message, Exception? exception = null)
    {
        return new(null, key, message, exception);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ErrorResult"/> with the specified context name, error key, message, and optional exception details.
    /// </summary>
    /// <param name="contextName">The name of the context associated with the error.</param>
    /// <param name="key">An optional key associated with the error.</param>
    /// <param name="message">The error message content.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <returns>A new instance of <see cref="ErrorResult"/>.</returns>
    internal static ErrorResult Create(string? contextName, string? key, string message, Exception? exception = null)
    {
        return new(contextName, key, message, exception);
    }
}