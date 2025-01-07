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
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the resource was found with the specified value.</returns>
    public Result<T> Found(T value)
    {
        SetValue(value);
        SetStatusCode(StatusCode.Found);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no modifications with the specified value.</returns>
    public Result<T> NotModified(T value)
    {
        SetValue(value);
        SetStatusCode(StatusCode.NotModified);
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
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public new Result<T> BadRequest(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadRequest);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public new Result<T> BadRequest(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadRequest);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public new Result<T> Unauthorized()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Unauthorized);
        return this;
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public new Result<T> Unauthorized(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Unauthorized);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public new Result<T> Unauthorized(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Unauthorized);
        SetTitle(title);
        SetDetail(detail);
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
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public new Result<T> Forbidden(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Forbidden);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public new Result<T> Forbidden(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Forbidden);
        SetTitle(title);
        SetDetail(detail);
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
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public new Result<T> NotFound(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.NotFound);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public new Result<T> NotFound(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.NotFound);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public new Result<T> MethodNotAllowed()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.MethodNotAllowed);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the method is not allowed.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public new Result<T> MethodNotAllowed(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.MethodNotAllowed);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public new Result<T> MethodNotAllowed(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.MethodNotAllowed);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the request timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public new Result<T> RequestTimeout()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.RequestTimeout);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the request timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the request timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public new Result<T> RequestTimeout(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.RequestTimeout);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the request timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public new Result<T> RequestTimeout(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.RequestTimeout);
        SetTitle(title);
        SetDetail(detail);
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
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public new Result<T> Conflict(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Conflict);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public new Result<T> Conflict(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.Conflict);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made in a given time period.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public new Result<T> TooManyRequests()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.TooManyRequests);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why too many requests were made.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public new Result<T> TooManyRequests(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.TooManyRequests);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public new Result<T> TooManyRequests(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.TooManyRequests);
        SetTitle(title);
        SetDetail(detail);
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
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public new Result<T> InternalServerError(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.InternalServerError);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public new Result<T> InternalServerError(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.InternalServerError);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public new Result<T> BadGateway()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadGateway);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing the bad gateway error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public new Result<T> BadGateway(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadGateway);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public new Result<T> BadGateway(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.BadGateway);
        SetTitle(title);
        SetDetail(detail);
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
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public new Result<T> ServiceUnavailable(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.ServiceUnavailable);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="title">A short title describing the service unavailability.</param>
    /// <param name="detail">A detailed message providing additional context about the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public new Result<T> ServiceUnavailable(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.ServiceUnavailable);
        SetTitle(title);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public new Result<T> GatewayTimeout()
    {
        SetValue(default!);
        SetStatusCode(StatusCode.GatewayTimeout);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the gateway timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public new Result<T> GatewayTimeout(string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.GatewayTimeout);
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public new Result<T> GatewayTimeout(string title, string detail)
    {
        SetValue(default!);
        SetStatusCode(StatusCode.GatewayTimeout);
        SetTitle(title);
        SetDetail(detail);
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