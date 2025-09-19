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
}