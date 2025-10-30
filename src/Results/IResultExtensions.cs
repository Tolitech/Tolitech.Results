using Tolitech.Results.Resources;

namespace Tolitech.Results;

/// <summary>
/// Provides extension methods for the <see cref="IResult"/> interface.
/// </summary>
public static partial class IResultExtensions
{
    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    public static IResult OK(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.OK);
    }

    /// <summary>
    /// Represents a result indicating successful creation.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating success.</returns>
    public static IResult Created(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.Created);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the request has been accepted for processing.</returns>
    public static IResult Accepted(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.Accepted);
    }

    /// <summary>
    /// Represents a result indicating no content.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no content.</returns>
    public static IResult NoContent(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.NoContent);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating that the resource was found.</returns>
    public static IResult Found(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.Found);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating no modifications.</returns>
    public static IResult NotModified(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.WithStatusCode(StatusCode.NotModified);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.BadRequest(ErrorMessageResources.BadRequest_Detail);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.BadRequest(ErrorMessageResources.BadRequest_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static IResult BadRequest(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.BadRequest);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Unauthorized(ErrorMessageResources.Unauthorized_Detail);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Unauthorized(ErrorMessageResources.Unauthorized_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static IResult Unauthorized(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Unauthorized);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Forbidden(ErrorMessageResources.Forbidden_Detail);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Forbidden(ErrorMessageResources.Forbidden_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static IResult Forbidden(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Forbidden);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.NotFound(ErrorMessageResources.NotFound_Detail);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.NotFound(ErrorMessageResources.NotFound_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static IResult NotFound(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.NotFound);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Conflict(ErrorMessageResources.Conflict_Detail);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.Conflict(ErrorMessageResources.Conflict_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static IResult Conflict(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.Conflict);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError(this IResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.InternalServerError(ErrorMessageResources.InternalServerError_Detail);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError(this IResult result, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result.InternalServerError(ErrorMessageResources.InternalServerError_Title, detail);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="result">The result instance to extend.</param>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static IResult InternalServerError(this IResult result, string title, string detail)
    {
        ArgumentNullException.ThrowIfNull(result);

        return result
            .WithTitle(title)
            .WithDetail(detail)
            .WithStatusCode(StatusCode.InternalServerError);
    }
}