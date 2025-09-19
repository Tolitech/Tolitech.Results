namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation, optionally containing a value and metadata such as status code, title, and
/// detail.
/// </summary>
/// <remarks>This interface extends <see cref="IResult"/> to include a strongly-typed value. It is commonly used
/// to represent the outcome of an operation, including success or failure states, associated messages, and optional
/// metadata.</remarks>
/// <typeparam name="T">The type of the value contained in the result.</typeparam>
public interface IResult<T> : IResult
{
    /// <summary>
    /// Gets the value stored in the current instance.
    /// </summary>
    T? Value { get; }

    /// <summary>
    /// Adds messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    new IResult<T> AddErrors(IResult result);

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    new IResult<T> WithTitle(string title);

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    new IResult<T> WithDetail(string detail);

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    new IResult<T> WithType(string? type);

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    new IResult<T> WithStatusCode(StatusCode statusCode);

    /// <summary>
    /// Sets the result with the specified value.
    /// </summary>
    /// <param name="value">The value to associate with the result.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    IResult<T> WithValue(T? value);

    /// <summary>
    /// Converts the current result to a new result type.
    /// </summary>
    /// <typeparam name="TNew">The type of the value in the new result.</typeparam>
    /// <returns>A new result of type <typeparamref name="TNew"/>. The conversion does not modify the state of the current
    /// result.</returns>
    IResult<TNew> ToResult<TNew>();

    /// <summary>
    /// Converts the current instance to a new result containing the specified value.
    /// </summary>
    /// <typeparam name="TNew">The type of the value to include in the new result.</typeparam>
    /// <param name="value">The value to include in the new result.</param>
    /// <returns>A new result containing the specified value.</returns>
    IResult<TNew> ToResult<TNew>(TNew? value);

    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating success with the specified value.</returns>
    static abstract IResult<T> OK(T? value);

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating success with the specified value.</returns>
    static abstract IResult<T> Created(T? value);

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    static abstract IResult<T> Accepted(T? value);

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    static new abstract IResult<T> NoContent();

    /// <summary>
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the resource was found with the specified value.</returns>
    static abstract IResult<T> Found(T? value);

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no modifications with the specified value.</returns>
    static abstract IResult<T> NotModified(T? value);

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static new abstract IResult<T> BadRequest();

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static new abstract IResult<T> BadRequest(string detail);

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    static new abstract IResult<T> BadRequest(string title, string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static new abstract IResult<T> Unauthorized();

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static new abstract IResult<T> Unauthorized(string detail);

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    static new abstract IResult<T> Unauthorized(string title, string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static new abstract IResult<T> Forbidden();

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static new abstract IResult<T> Forbidden(string detail);

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    static new abstract IResult<T> Forbidden(string title, string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static new abstract IResult<T> NotFound();

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static new abstract IResult<T> NotFound(string detail);

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    static new abstract IResult<T> NotFound(string title, string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static new abstract IResult<T> Conflict();

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static new abstract IResult<T> Conflict(string detail);

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    static new abstract IResult<T> Conflict(string title, string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static new abstract IResult<T> InternalServerError();

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static new abstract IResult<T> InternalServerError(string detail);

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    static new abstract IResult<T> InternalServerError(string title, string detail);
}