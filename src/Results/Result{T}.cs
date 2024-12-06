namespace Tolitech.Results;

/// <summary>
/// Represents a result with a typed value, success status, and optional metadata.
/// </summary>
/// <typeparam name="T">The type of the result value.</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value, success status, and status code.
    /// </summary>
    public Result()
        : base(true, StatusCode.NoContent)
    {
        Value = default!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value, success status, and status code.
    /// </summary>
    /// <param name="value">The result value.</param>
    /// <param name="isSuccess">The success status of the result.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    protected internal Result(T value, bool isSuccess, StatusCode statusCode)
        : base(isSuccess, statusCode)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified success status and status code.
    /// </summary>
    /// <param name="isSuccess">The success status of the result.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    protected internal Result(bool isSuccess, StatusCode statusCode)
        : base(isSuccess, statusCode)
    {
        Value = default!;
    }

    /// <summary>
    /// Gets the typed value of the result.
    /// </summary>
    public T Value { get; private set; }

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
    public new Result<T> WithTitle(string title)
    {
        SetTitle(title);
        return this;
    }

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
    public new Result<T> WithDetail(string detail)
    {
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public new Result<T> WithType(string type)
    {
        SetType(type);
        return this;
    }

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
    public new Result<T> WithStatusCode(StatusCode statusCode)
    {
        SetStatusCode(statusCode);
        return this;
    }

    /// <summary>
    /// Sets the context name metadata for the result.
    /// </summary>
    /// <param name="contextName">The context name to set.</param>
    /// <returns>The current instance of <see cref="Result{T}"/>.</returns>
    public new Result<T> WithContext(string contextName)
    {
        SetContextName(contextName);
        return this;
    }

    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public Result<T> OK(T value)
    {
        SetValue(value);
        SetStatusCode(StatusCode.OK);
        return this;
    }

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public Result<T> Created(T value)
    {
        SetValue(value);
        SetStatusCode(StatusCode.Created);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    public Result<T> Accepted(T value)
    {
        SetValue(value);
        SetStatusCode(StatusCode.Accepted);
        return this;
    }

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    public new Result<T> NoContent()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.NoContent);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public new Result<T> BadRequest()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadRequest);
        return this;
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public new Result<T> Forbidden()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Forbidden);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public new Result<T> NotFound()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.NotFound);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public new Result<T> Conflict()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Conflict);
        return this;
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public new Result<T> InternalServerError()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.InternalServerError);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public new Result<T> ServiceUnavailable()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.ServiceUnavailable);
        return this;
    }

    /// <summary>
    /// Sets the value of the result.
    /// </summary>
    /// <param name="value">The value to set.</param>
    private void SetValue(T value)
    {
        Value = value;
    }
}