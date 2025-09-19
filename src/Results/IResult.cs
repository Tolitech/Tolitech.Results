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

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    static abstract IResult OK();

    /// <summary>
    /// Represents a result indicating successful creation.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    static abstract IResult Created();

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the request has been accepted for processing.</returns>
    static abstract IResult Accepted();

    /// <summary>
    /// Represents a result indicating no content.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no content.</returns>
    static abstract IResult NoContent();

    /// <summary>
    /// Represents a result indicating that the requested resource was found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the resource was found.</returns>
    static abstract IResult Found();

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no modifications.</returns>
    static abstract IResult NotModified();

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static abstract IResult BadRequest();

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static abstract IResult BadRequest(string detail);

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static abstract IResult BadRequest(string title, string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static abstract IResult Unauthorized();

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static abstract IResult Unauthorized(string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static abstract IResult Unauthorized(string title, string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static abstract IResult Forbidden();

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static abstract IResult Forbidden(string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static abstract IResult Forbidden(string title, string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static abstract IResult NotFound();

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static abstract IResult NotFound(string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static abstract IResult NotFound(string title, string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static abstract IResult Conflict();

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static abstract IResult Conflict(string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static abstract IResult Conflict(string title, string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static abstract IResult InternalServerError();

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static abstract IResult InternalServerError(string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static abstract IResult InternalServerError(string title, string detail);
}