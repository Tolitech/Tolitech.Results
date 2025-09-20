namespace Tolitech.Results;

/// <summary>
/// Provides extension methods for the <see cref="IResult"/> interface.
/// </summary>
public static partial class IResultExtensions
{
    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="value">The typed value.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating success with the specified value.</returns>
    public static IResult<T> OK<T>(this IResult<T> result, T? value)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.OK)
            .WithValue(value);
    }

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="value">The typed value.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating success with the specified value.</returns>
    public static IResult<T> Created<T>(this IResult<T> result, T? value)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Created)
            .WithValue(value);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="value">The typed value.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    public static IResult<T> Accepted<T>(this IResult<T> result, T? value)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Accepted)
            .WithValue(value);
    }

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    public static IResult<T> NoContent<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.NoContent)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="value">The typed value.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the resource was found with the specified value.</returns>
    public static IResult<T> Found<T>(this IResult<T> result, T? value)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Found)
            .WithValue(value);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="value">The typed value.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no modifications with the specified value.</returns>
    public static IResult<T> NotModified<T>(this IResult<T> result, T? value)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.NotModified)
            .WithValue(value);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static IResult<T> BadRequest<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.BadRequest)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static IResult<T> BadRequest<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.BadRequest)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static IResult<T> BadRequest<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.BadRequest)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static IResult<T> Unauthorized<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Unauthorized)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static IResult<T> Unauthorized<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Unauthorized)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static IResult<T> Unauthorized<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Unauthorized)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static IResult<T> Forbidden<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Forbidden)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static IResult<T> Forbidden<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Forbidden)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static IResult<T> Forbidden<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Forbidden)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static IResult<T> NotFound<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.NotFound)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static IResult<T> NotFound<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.NotFound)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static IResult<T> NotFound<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.NotFound)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static IResult<T> Conflict<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.Conflict)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static IResult<T> Conflict<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Conflict)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static IResult<T> Conflict<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Conflict)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static IResult<T> InternalServerError<T>(this IResult<T> result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithStatusCode(StatusCode.InternalServerError)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static IResult<T> InternalServerError<T>(this IResult<T> result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithDetail(detail)
            .WithStatusCode(StatusCode.InternalServerError)
            .WithValue(default);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static IResult<T> InternalServerError<T>(this IResult<T> result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.InternalServerError)
            .WithValue(default);
    }
}