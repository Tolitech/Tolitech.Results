namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation with optional metadata and messages.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Gets the title metadata associated with the result.
    /// </summary>
    string? Title { get; }

    /// <summary>
    /// Gets the detail metadata associated with the result.
    /// </summary>
    string? Detail { get; }

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
    /// Gets a collection of message results associated with the result.
    /// </summary>
    IReadOnlyCollection<MessageResult> Messages { get; }

    /// <summary>
    /// Gets a collection of error message results associated with the result.
    /// </summary>
    IEnumerable<MessageResult> Errors { get; }

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating success.</returns>
    static abstract Result OK();

    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    static abstract Result<T> OK<T>(T value);

    /// <summary>
    /// Represents a result indicating successful creation.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating success.</returns>
    static abstract Result Created();

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    static abstract Result<T> Created<T>(T value);

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the request has been accepted for processing.</returns>
    static abstract Result Accepted();

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    static abstract Result<T> Accepted<T>(T value);

    /// <summary>
    /// Represents a result indicating no content.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating no content.</returns>
    static abstract Result NoContent();

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    static abstract Result<T> NoContent<T>();

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    static abstract Result BadRequest();

    /// <summary>
    /// Represents a result indicating a bad request with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a bad request with the specified value.</returns>
    static abstract Result<T> BadRequest<T>(T value);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    static abstract Result Forbidden();

    /// <summary>
    /// Represents a result indicating forbidden access with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating forbidden access with the default value for type <typeparamref name="T"/>.</returns>
    static abstract Result<T> Forbidden<T>();

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    static abstract Result NotFound();

    /// <summary>
    /// Represents a result indicating a resource not found with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a resource not found with the specified value.</returns>
    static abstract Result<T> NotFound<T>(T value);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    static abstract Result Conflict();

    /// <summary>
    /// Represents a result indicating a conflict with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a conflict with the specified value.</returns>
    static abstract Result<T> Conflict<T>(T value);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    static abstract Result InternalServerError();

    /// <summary>
    /// Represents a result indicating an internal server error with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating an internal server error with the specified value.</returns>
    static abstract Result<T> InternalServerError<T>(T value);

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    static abstract Result ServiceUnavailable();

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the service is currently unavailable with the specified value.</returns>
    static abstract Result<T> ServiceUnavailable<T>(T value);

    /// <summary>
    /// Adds an informational message to the result.
    /// </summary>
    /// <param name="message">The informational message content.</param>
    void AddInformation(string message);

    /// <summary>
    /// Adds an informational message to the result with an optional key.
    /// </summary>
    /// <param name="key">An optional key associated with the informational message.</param>
    /// <param name="message">The informational message content.</param>
    void AddInformation(string? key, string message);

    /// <summary>
    /// Adds a warning message to the result.
    /// </summary>
    /// <param name="message">The warning message content.</param>
    void AddWarning(string message);

    /// <summary>
    /// Adds a warning message to the result with an optional key.
    /// </summary>
    /// <param name="key">An optional key associated with the warning message.</param>
    /// <param name="message">The warning message content.</param>
    void AddWarning(string? key, string message);

    /// <summary>
    /// Adds an error message to the result with an optional status code and exception.
    /// </summary>
    /// <param name="message">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    void AddError(string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null);

    /// <summary>
    /// Adds an error message to the result with an optional key, status code, and exception.
    /// </summary>
    /// <param name="key">An optional key associated with the error message.</param>
    /// <param name="message">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    void AddError(string? key, string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null);
}