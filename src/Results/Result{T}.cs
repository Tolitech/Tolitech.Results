using Tolitech.Results.Resources;

namespace Tolitech.Results;

/// <summary>
/// Represents a result with a typed value, success status, and optional metadata.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
public class Result<T> : Result, IResult<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value, success status, and status code.
    /// </summary>
    /// <param name="isSuccess">The success status of the result.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    protected internal Result(bool isSuccess, StatusCode statusCode)
        : base(isSuccess, statusCode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value, success status, and status code.
    /// </summary>
    /// <param name="isSuccess">The success status of the result.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    /// <param name="value">The result value.</param>
    protected internal Result(bool isSuccess, StatusCode statusCode, T? value)
        : base(isSuccess, statusCode)
    {
        Value = value;
    }

    /// <summary>
    /// Gets the typed value of the result.
    /// </summary>
    public T? Value { get; private set; }

    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public static IResult<T> OK(T? value)
    {
        return new Result<T>(true, StatusCode.OK, value);
    }

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public static IResult<T> Created(T? value)
    {
        return new Result<T>(true, StatusCode.Created, value);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    public static IResult<T> Accepted(T? value)
    {
        return new Result<T>(true, StatusCode.Accepted, value);
    }

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    public static new IResult<T> NoContent()
    {
        return new Result<T>(true, StatusCode.NoContent, default);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating that the resource was found with the specified value.</returns>
    public static IResult<T> Found(T? value)
    {
        return new Result<T>(true, StatusCode.Found, value);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="IResult{T}"/> class indicating no modifications with the specified value.</returns>
    public static IResult<T> NotModified(T? value)
    {
        return new Result<T>(true, StatusCode.NotModified, value);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static new IResult<T> BadRequest()
    {
        return new Result<T>(false, StatusCode.BadRequest) { Title = ErrorMessageResources.BadRequest_Title, Detail = ErrorMessageResources.BadRequest_Detail };
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static new IResult<T> BadRequest(string detail)
    {
        return new Result<T>(false, StatusCode.BadRequest) { Title = ErrorMessageResources.BadRequest_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a bad request.</returns>
    public static new IResult<T> BadRequest(string title, string detail)
    {
        return new Result<T>(false, StatusCode.BadRequest) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static new IResult<T> Unauthorized()
    {
        return new Result<T>(false, StatusCode.Unauthorized) { Title = ErrorMessageResources.Unauthorized_Title, Detail = ErrorMessageResources.Unauthorized_Detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static new IResult<T> Unauthorized(string detail)
    {
        return new Result<T>(false, StatusCode.Unauthorized) { Title = ErrorMessageResources.Unauthorized_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating unauthorized access.</returns>
    public static new IResult<T> Unauthorized(string title, string detail)
    {
        return new Result<T>(false, StatusCode.Unauthorized) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static new IResult<T> Forbidden()
    {
        return new Result<T>(false, StatusCode.Forbidden) { Title = ErrorMessageResources.Forbidden_Title, Detail = ErrorMessageResources.Forbidden_Detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static new IResult<T> Forbidden(string detail)
    {
        return new Result<T>(false, StatusCode.Forbidden) { Title = ErrorMessageResources.Forbidden_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating forbidden access.</returns>
    public static new IResult<T> Forbidden(string title, string detail)
    {
        return new Result<T>(false, StatusCode.Forbidden) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static new IResult<T> NotFound()
    {
        return new Result<T>(false, StatusCode.NotFound) { Title = ErrorMessageResources.NotFound_Title, Detail = ErrorMessageResources.NotFound_Detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static new IResult<T> NotFound(string detail)
    {
        return new Result<T>(false, StatusCode.NotFound) { Title = ErrorMessageResources.NotFound_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a resource not found.</returns>
    public static new IResult<T> NotFound(string title, string detail)
    {
        return new Result<T>(false, StatusCode.NotFound) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static new IResult<T> Conflict()
    {
        return new Result<T>(false, StatusCode.Conflict) { Title = ErrorMessageResources.Conflict_Title, Detail = ErrorMessageResources.Conflict_Detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static new IResult<T> Conflict(string detail)
    {
        return new Result<T>(false, StatusCode.Conflict) { Title = ErrorMessageResources.Conflict_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating a conflict.</returns>
    public static new IResult<T> Conflict(string title, string detail)
    {
        return new Result<T>(false, StatusCode.Conflict) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static new IResult<T> InternalServerError()
    {
        return new Result<T>(false, StatusCode.InternalServerError) { Title = ErrorMessageResources.InternalServerError_Title, Detail = ErrorMessageResources.InternalServerError_Detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static new IResult<T> InternalServerError(string detail)
    {
        return new Result<T>(false, StatusCode.InternalServerError) { Title = ErrorMessageResources.InternalServerError_Title, Detail = detail };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="IResult"/> class indicating an internal server error.</returns>
    public static new IResult<T> InternalServerError(string title, string detail)
    {
        return new Result<T>(false, StatusCode.InternalServerError) { Title = title, Detail = detail };
    }

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="IResult{T}"/>.</returns>
    public new IResult<T> WithTitle(string title)
    {
        base.WithTitle(title);
        return this;
    }

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="IResult{T}"/>.</returns>
    public new IResult<T> WithDetail(string detail)
    {
        base.WithDetail(detail);
        return this;
    }

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public new IResult<T> WithType(string? type)
    {
        base.WithType(type);
        return this;
    }

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="IResult{T}"/>.</returns>
    public new IResult<T> WithStatusCode(StatusCode statusCode)
    {
        base.WithStatusCode(statusCode);
        return this;
    }

    /// <summary>
    /// Sets the value of the result.
    /// </summary>
    /// <param name="value">The value to set.</param>
    /// <returns>The current instance of <see cref="IResult{T}"/>.</returns>
    public IResult<T> WithValue(T? value)
    {
        Value = value;
        return this;
    }

    /// <summary>
    /// Adds messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    /// <returns>The current instance of <see cref="IResult"/>.</returns>
    public new IResult<T> AddErrors(IResult result)
    {
        base.AddErrors(result);
        return this;
    }

    /// <summary>
    /// Converts the current result to a new result with a different value type.
    /// </summary>
    /// <typeparam name="TNew">The type of the value in the new result.</typeparam>
    /// <returns>A new result of type <typeparamref name="TNew"/> that retains the success status and status code of the current
    /// result.</returns>
    public IResult<TNew> ToResult<TNew>()
    {
        IResult<TNew> result = new Result<TNew>(IsSuccess, StatusCode);
        return FromCurrentToNewResult(result);
    }

    /// <summary>
    /// Converts the current result to a new result with a specified value.
    /// </summary>
    /// <typeparam name="TNew">The type of the value for the new result.</typeparam>
    /// <param name="value">The value to associate with the new result. Can be <see langword="null"/> if the type <typeparamref
    /// name="TNew"/> allows it.</param>
    /// <returns>A new result of type <typeparamref name="TNew"/> that retains the success state and status code of the current
    /// result.</returns>
    public IResult<TNew> ToResult<TNew>(TNew? value)
    {
        IResult<TNew> result = new Result<TNew>(IsSuccess, StatusCode, value);
        return FromCurrentToNewResult(result);
    }

    /// <summary>
    /// Converts the current result to a new result of the specified type, transferring common metadata such as title,
    /// detail, type, and status code, and appending any errors from the current result.
    /// </summary>
    /// <typeparam name="TNew">The type of the new result.</typeparam>
    /// <param name="result">The new result instance to which metadata and errors will be transferred.  This parameter cannot be <see
    /// langword="null"/>.</param>
    /// <returns>The updated result of type <typeparamref name="TNew"/> with transferred metadata and errors.</returns>
    private IResult<TNew> FromCurrentToNewResult<TNew>(IResult<TNew> result)
    {
        result
            .WithTitle(Title)
            .WithDetail(Detail)
            .WithType(Type)
            .WithStatusCode(StatusCode)
            .AddErrors(this);

        return result;
    }
}