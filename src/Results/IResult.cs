namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation with optional metadata and messages.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Gets the title metadata associated with the result.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Gets the detail metadata associated with the result.
    /// </summary>
    string Detail { get; }

    /// <summary>
    /// Gets the type metadata associated with the result.
    /// </summary>
    string? Type { get; }

    /// <summary>
    /// Gets the status code associated with the result.
    /// </summary>
    StatusCode StatusCode { get; }

    /// <summary>
    /// Gets a value indicating whether the result indicates success.
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result indicates failure.
    /// </summary>
    bool IsFailure { get; }

    /// <summary>
    /// Gets a collection of error message results associated with the result.
    /// </summary>
    IReadOnlyCollection<ErrorMessage> Errors { get; }

    /// <summary>
    /// Adds an error message to the result with an optional status code and exception.
    /// </summary>
    /// <param name="errorMessage">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    void AddError(string errorMessage, StatusCode statusCode = StatusCode.BadRequest);

    /// <summary>
    /// Adds an error message to the result with an optional key, status code, and exception.
    /// </summary>
    /// <param name="key">An optional key associated with the error message.</param>
    /// <param name="errorMessage">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    void AddError(string? key, string errorMessage, StatusCode statusCode = StatusCode.BadRequest);

    /// <summary>
    /// Adds error messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult AddErrors(IResult result);

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult WithTitle(string title);

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult WithDetail(string detail);

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult WithType(string? type);

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult WithStatusCode(StatusCode statusCode);
}