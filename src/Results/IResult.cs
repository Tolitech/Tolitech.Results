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
    /// Represents a result indicating that the requested resource was found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the resource was found.</returns>
    static abstract Result Found();

    /// <summary>
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the resource was found with the specified value.</returns>
    static abstract Result<T> Found<T>(T value);

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating no modifications.</returns>
    static abstract Result NotModified();

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no modifications with the specified value.</returns>
    static abstract Result<T> NotModified<T>(T value);

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    static abstract Result BadRequest();

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    static abstract Result BadRequest(string detail);

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    static abstract Result BadRequest(string title, string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    static abstract Result Unauthorized();

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    static abstract Result Unauthorized(string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    static abstract Result Unauthorized(string title, string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    static abstract Result Forbidden();

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    static abstract Result Forbidden(string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    static abstract Result Forbidden(string title, string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    static abstract Result NotFound();

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    static abstract Result NotFound(string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    static abstract Result NotFound(string title, string detail);

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    static abstract Result MethodNotAllowed();

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the method is not allowed.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    static abstract Result MethodNotAllowed(string detail);

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    static abstract Result MethodNotAllowed(string title, string detail);

    /// <summary>
    /// Represents a result indicating that the request timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    static abstract Result RequestTimeout();

    /// <summary>
    /// Represents a result indicating that the request timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the request timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    static abstract Result RequestTimeout(string detail);

    /// <summary>
    /// Represents a result indicating that the request timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    static abstract Result RequestTimeout(string title, string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    static abstract Result Conflict();

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    static abstract Result Conflict(string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    static abstract Result Conflict(string title, string detail);

    /// <summary>
    /// Represents a result indicating that too many requests were made in a given time period.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    static abstract Result TooManyRequests();

    /// <summary>
    /// Represents a result indicating that too many requests were made with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why too many requests were made.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    static abstract Result TooManyRequests(string detail);

    /// <summary>
    /// Represents a result indicating that too many requests were made with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    static abstract Result TooManyRequests(string title, string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    static abstract Result InternalServerError();

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    static abstract Result InternalServerError(string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    static abstract Result InternalServerError(string title, string detail);

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    static abstract Result BadGateway();

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing the bad gateway error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    static abstract Result BadGateway(string detail);

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    static abstract Result BadGateway(string title, string detail);

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    static abstract Result ServiceUnavailable();

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    static abstract Result ServiceUnavailable(string detail);

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="title">A short title describing the service unavailability.</param>
    /// <param name="detail">A detailed message providing additional context about the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    static abstract Result ServiceUnavailable(string title, string detail);

    /// <summary>
    /// Represents a result indicating that the gateway timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    static abstract Result GatewayTimeout();

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the gateway timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    static abstract Result GatewayTimeout(string detail);

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    static abstract Result GatewayTimeout(string title, string detail);

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