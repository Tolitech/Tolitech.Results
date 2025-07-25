namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation with optional metadata and messages.
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// Represents a list of message results associated with the result.
    /// </summary>
    private List<MessageResult>? _messages;

    /// <summary>
    /// Represents the context name associated with the result.
    /// </summary>
    private string? _contextName;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified success status and status code.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the result is successful.</param>
    /// <param name="statusCode">The status code associated with the result.</param>
    protected internal Result(bool isSuccess, StatusCode statusCode)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets the title metadata associated with the result.
    /// </summary>
    public string? Title { get; private set; }

    /// <summary>
    /// Gets the detail metadata associated with the result.
    /// </summary>
    public string? Detail { get; private set; }

    /// <summary>
    /// Gets the type metadata associated with the result.
    /// </summary>
    public string? Type { get; private set; }

    /// <summary>
    /// Gets or sets the status code associated with the result.
    /// </summary>
    public StatusCode StatusCode { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the result indicates success.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the result indicates failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets a collection of message results associated with the result.
    /// </summary>
    public IReadOnlyCollection<MessageResult> Messages => _messages ?? [];

    /// <summary>
    /// Gets a collection of error message results associated with the result.
    /// </summary>
    public IEnumerable<MessageResult> Errors => _messages is null ? [] : _messages.Where(x => x.Type == MessageType.Error);

    /// <summary>
    /// Represents a successful result.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating success.</returns>
    public static Result OK()
    {
        return new(true, StatusCode.OK);
    }

    /// <summary>
    /// Represents a successful result with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public static Result<T> OK<T>(T value)
    {
        return new(value, true, StatusCode.OK);
    }

    /// <summary>
    /// Represents a result indicating successful creation.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating success.</returns>
    public static Result Created()
    {
        return new(true, StatusCode.Created);
    }

    /// <summary>
    /// Represents a result indicating successful creation with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating success with the specified value.</returns>
    public static Result<T> Created<T>(T value)
    {
        return new(value, true, StatusCode.Created);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing, but the processing has not been completed.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the request has been accepted for processing.</returns>
    public static Result Accepted()
    {
        return new(true, StatusCode.Accepted);
    }

    /// <summary>
    /// Represents a result indicating that the request has been accepted for processing with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the request has been accepted for processing with the specified value.</returns>
    public static Result<T> Accepted<T>(T value)
    {
        return new(value, true, StatusCode.Accepted);
    }

    /// <summary>
    /// Represents a result indicating no content.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating no content.</returns>
    public static Result NoContent()
    {
        return new(true, StatusCode.NoContent);
    }

    /// <summary>
    /// Represents a result indicating no content with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no content with the default value for type <typeparamref name="T"/>.</returns>
    public static Result<T> NoContent<T>()
    {
        return new(true, StatusCode.NoContent);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the resource was found.</returns>
    public static Result Found()
    {
        return new(true, StatusCode.Found);
    }

    /// <summary>
    /// Represents a result indicating that the requested resource was found with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the resource was found with the specified value.</returns>
    public static Result<T> Found<T>(T value)
    {
        return new(value, true, StatusCode.Found);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating no modifications.</returns>
    public static Result NotModified()
    {
        return new(true, StatusCode.NotModified);
    }

    /// <summary>
    /// Represents a result indicating that no modifications were made to the requested resource with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating no modifications with the specified value.</returns>
    public static Result<T> NotModified<T>(T value)
    {
        return new(value, true, StatusCode.NotModified);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static Result BadRequest()
    {
        return new(false, StatusCode.BadRequest);
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static Result BadRequest(string detail)
    {
        return new(false, StatusCode.BadRequest)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <param name="title">A short title describing the bad request.</param>
    /// <param name="detail">A detailed message providing additional context about the bad request.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static Result BadRequest(string title, string detail)
    {
        return new(false, StatusCode.BadRequest)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static Result Unauthorized()
    {
        return new(false, StatusCode.Unauthorized);
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with additional details.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static Result Unauthorized(string detail)
    {
        return new(false, StatusCode.Unauthorized)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating unauthorized access with a specific title and additional details.
    /// </summary>
    /// <param name="title">A short title describing the unauthorized access.</param>
    /// <param name="detail">A detailed message providing additional context about the unauthorized access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating unauthorized access.</returns>
    public static Result Unauthorized(string title, string detail)
    {
        return new(false, StatusCode.Unauthorized)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static Result Forbidden()
    {
        return new(false, StatusCode.Forbidden);
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="detail">A detailed message providing the reason for the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static Result Forbidden(string detail)
    {
        return new(false, StatusCode.Forbidden)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating forbidden access.
    /// </summary>
    /// <param name="title">A short title describing the forbidden access.</param>
    /// <param name="detail">A detailed message providing additional context about the forbidden access.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating forbidden access.</returns>
    public static Result Forbidden(string title, string detail)
    {
        return new(false, StatusCode.Forbidden)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static Result NotFound()
    {
        return new(false, StatusCode.NotFound);
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="detail">A detailed message describing why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static Result NotFound(string detail)
    {
        return new(false, StatusCode.NotFound)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating a resource not found.
    /// </summary>
    /// <param name="title">A short title describing the resource not found.</param>
    /// <param name="detail">A detailed message providing additional context about why the resource was not found.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a resource not found.</returns>
    public static Result NotFound(string title, string detail)
    {
        return new(false, StatusCode.NotFound)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public static Result MethodNotAllowed()
    {
        return new(false, StatusCode.MethodNotAllowed);
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the method is not allowed.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public static Result MethodNotAllowed(string detail)
    {
        return new(false, StatusCode.MethodNotAllowed)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the HTTP method is not allowed for the requested resource with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the method is not allowed.</returns>
    public static Result MethodNotAllowed(string title, string detail)
    {
        return new(false, StatusCode.MethodNotAllowed)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the request timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public static Result RequestTimeout()
    {
        return new(false, StatusCode.RequestTimeout);
    }

    /// <summary>
    /// Represents a result indicating that the request timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the request timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public static Result RequestTimeout(string detail)
    {
        return new(false, StatusCode.RequestTimeout)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the request timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a request timeout.</returns>
    public static Result RequestTimeout(string title, string detail)
    {
        return new(false, StatusCode.RequestTimeout)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static Result Conflict()
    {
        return new(false, StatusCode.Conflict);
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static Result Conflict(string detail)
    {
        return new(false, StatusCode.Conflict)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating a conflict.
    /// </summary>
    /// <param name="title">A short title describing the conflict.</param>
    /// <param name="detail">A detailed message providing additional context about the conflict.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a conflict.</returns>
    public static Result Conflict(string title, string detail)
    {
        return new(false, StatusCode.Conflict)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made in a given time period.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public static Result TooManyRequests()
    {
        return new(false, StatusCode.TooManyRequests);
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why too many requests were made.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public static Result TooManyRequests(string detail)
    {
        return new(false, StatusCode.TooManyRequests)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that too many requests were made with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating too many requests.</returns>
    public static Result TooManyRequests(string title, string detail)
    {
        return new(false, StatusCode.TooManyRequests)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static Result InternalServerError()
    {
        return new(false, StatusCode.InternalServerError);
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="detail">A detailed message describing the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static Result InternalServerError(string detail)
    {
        return new(false, StatusCode.InternalServerError)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating an internal server error.
    /// </summary>
    /// <param name="title">A short title describing the internal server error.</param>
    /// <param name="detail">A detailed message providing additional context about the internal server error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating an internal server error.</returns>
    public static Result InternalServerError(string title, string detail)
    {
        return new(false, StatusCode.InternalServerError)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public static Result BadGateway()
    {
        return new(false, StatusCode.BadGateway);
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing the bad gateway error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public static Result BadGateway(string detail)
    {
        return new(false, StatusCode.BadGateway)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the server encountered an error and acted as a bad gateway with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad gateway error.</returns>
    public static Result BadGateway(string title, string detail)
    {
        return new(false, StatusCode.BadGateway)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public static Result ServiceUnavailable()
    {
        return new(false, StatusCode.ServiceUnavailable);
    }

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="detail">A detailed message describing the reason for the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public static Result ServiceUnavailable(string detail)
    {
        return new(false, StatusCode.ServiceUnavailable)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the service is currently unavailable.
    /// </summary>
    /// <param name="title">A short title describing the service unavailability.</param>
    /// <param name="detail">A detailed message providing additional context about the service unavailability.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating that the service is currently unavailable.</returns>
    public static Result ServiceUnavailable(string title, string detail)
    {
        return new(false, StatusCode.ServiceUnavailable)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public static Result GatewayTimeout()
    {
        return new(false, StatusCode.GatewayTimeout);
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a detailed message.
    /// </summary>
    /// <param name="detail">A detailed message describing why the gateway timed out.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public static Result GatewayTimeout(string detail)
    {
        return new(false, StatusCode.GatewayTimeout)
        {
            Detail = detail,
        };
    }

    /// <summary>
    /// Represents a result indicating that the gateway timed out with a specific title and detailed message.
    /// </summary>
    /// <param name="title">A short title describing the error.</param>
    /// <param name="detail">A detailed message providing additional context about the error.</param>
    /// <returns>An instance of the <see cref="Result"/> class indicating a gateway timeout.</returns>
    public static Result GatewayTimeout(string title, string detail)
    {
        return new(false, StatusCode.GatewayTimeout)
        {
            Title = title,
            Detail = detail,
        };
    }

    /// <summary>
    /// Adds an informational message to the result.
    /// </summary>
    /// <param name="message">The informational message content.</param>
    public void AddInformation(string message)
    {
        AddInformation(null, message);
    }

    /// <summary>
    /// Adds an informational message to the result with an optional key.
    /// </summary>
    /// <param name="key">An optional key associated with the informational message.</param>
    /// <param name="message">The informational message content.</param>
    public void AddInformation(string? key, string message)
    {
        AddMessageResult(MessageResult.Information(_contextName, key, message));
    }

    /// <summary>
    /// Adds a warning message to the result.
    /// </summary>
    /// <param name="message">The warning message content.</param>
    public void AddWarning(string message)
    {
        AddWarning(null, message);
    }

    /// <summary>
    /// Adds a warning message to the result with an optional key.
    /// </summary>
    /// <param name="key">An optional key associated with the warning message.</param>
    /// <param name="message">The warning message content.</param>
    public void AddWarning(string? key, string message)
    {
        AddMessageResult(MessageResult.Warning(_contextName, key, message));
    }

    /// <summary>
    /// Adds an error message to the result with an optional status code and exception.
    /// </summary>
    /// <param name="message">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    public void AddError(string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null)
    {
        AddError(null, message, statusCode, exception);
    }

    /// <summary>
    /// Adds an error message to the result with an optional key, status code, and exception.
    /// </summary>
    /// <param name="key">An optional key associated with the error message.</param>
    /// <param name="message">The error message content.</param>
    /// <param name="statusCode">An optional status code associated with the error.</param>
    /// <param name="exception">An optional exception associated with the error.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the provided <paramref name="statusCode"/> represents a success state.
    /// Only error statuses are valid for this method.
    /// </exception>
    public void AddError(string? key, string message, StatusCode statusCode = StatusCode.BadRequest, Exception? exception = null)
    {
        if (IsStatusCodeSuccess(statusCode))
        {
            throw new InvalidOperationException("Cannot add an error message with a success status code.");
        }

        if (IsSuccess)
        {
            IsSuccess = false;
            StatusCode = statusCode;
        }

        AddMessageResult(ErrorResult.Create(_contextName, key, message, exception));
    }

    /// <summary>
    /// Adds messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result AddMessages(IResult result)
    {
        if (result is not null)
        {
            if (IsSuccess && result.IsFailure)
            {
                SetTitle(result.Title);
                SetDetail(result.Detail);
                SetType(result.Type);
                SetStatusCode(result.StatusCode);
            }

            AddMessageResult(result.Messages);
        }

        return this;
    }

    /// <summary>
    /// Sets the title metadata for the result.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result WithTitle(string title)
    {
        SetTitle(title);
        return this;
    }

    /// <summary>
    /// Sets the detail metadata for the result.
    /// </summary>
    /// <param name="detail">The detail to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result WithDetail(string detail)
    {
        SetDetail(detail);
        return this;
    }

    /// <summary>
    /// Sets the type metadata for the result.
    /// </summary>
    /// <param name="type">The type to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result WithType(string type)
    {
        SetType(type);
        return this;
    }

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result WithStatusCode(StatusCode statusCode)
    {
        SetStatusCode(statusCode);
        return this;
    }

    /// <summary>
    /// Sets the context name metadata for the result.
    /// </summary>
    /// <param name="contextName">The context name to set.</param>
    /// <returns>The current instance of <see cref="Result"/>.</returns>
    public Result WithContext(string contextName)
    {
        SetContextName(contextName);
        return this;
    }

    /// <summary>
    /// Converts the current result to a generic <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> instance based on the current result.</returns>
    public Result<T> ToResult<T>()
    {
        Result<T> result = new(IsSuccess, StatusCode);
        return ConvertToNewResult(result);
    }

    /// <summary>
    /// Converts the current result to a generic <see cref="Result{T}"/> with a specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the result.</typeparam>
    /// <param name="value">The value associated with the result.</param>
    /// <returns>A <see cref="Result{T}"/> instance based on the current result with the specified value.</returns>
    public Result<T> ToResult<T>(T value)
    {
        Result<T> result = new(value, IsSuccess, StatusCode);
        return ConvertToNewResult(result);
    }

    /// <summary>
    /// Sets the title metadata associated with the result.
    /// </summary>
    /// <param name="title">The title to be set.</param>
    protected void SetTitle(string? title)
    {
        Title = title;
    }

    /// <summary>
    /// Sets the detail metadata associated with the result.
    /// </summary>
    /// <param name="detail">The detail to be set.</param>
    protected void SetDetail(string? detail)
    {
        Detail = detail;
    }

    /// <summary>
    /// Sets the type metadata associated with the result.
    /// </summary>
    /// <param name="type">The type to be set.</param>
    protected void SetType(string? type)
    {
        Type = type;
    }

    /// <summary>
    /// Sets the context name associated with the result.
    /// </summary>
    /// <param name="contextName">The context name to be set.</param>
    protected void SetContextName(string contextName)
    {
        _contextName = contextName;
    }

    /// <summary>
    /// Sets the status code for the result.
    /// </summary>
    /// <param name="statusCode">The status code to set.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to set a success status code while error messages exist in the <see cref="Messages"/> collection.
    /// This ensures that an object with error messages cannot be marked as successful.
    /// </exception>
    protected void SetStatusCode(StatusCode statusCode)
    {
        if (!IsSuccess && IsStatusCodeSuccess(statusCode))
        {
            IsSuccess = true;
        }
        else if (IsSuccess && !IsStatusCodeSuccess(statusCode))
        {
            IsSuccess = false;
        }

        if (Messages.Any(x => x.Type == MessageType.Error) && IsStatusCodeSuccess(statusCode))
        {
            throw new InvalidOperationException("Unable to set a success status because there are error messages associated with the object.");
        }

        StatusCode = statusCode;
    }

    /// <summary>
    /// Determines whether the provided status code represents a successful response.
    /// </summary>
    /// <param name="statusCode">The status code to check.</param>
    /// <returns>True if the status code represents a successful response; otherwise, false.</returns>
    private static bool IsStatusCodeSuccess(StatusCode statusCode)
    {
        return statusCode is
            StatusCode.OK or
            StatusCode.Created or
            StatusCode.Accepted or
            StatusCode.NoContent or
            StatusCode.Found or
            StatusCode.NotModified;
    }

    /// <summary>
    /// Converts the specified <paramref name="result"/> to a new <see cref="Result{T}"/> with additional details.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the result.</typeparam>
    /// <param name="result">The result to be converted.</param>
    /// <returns>A new <see cref="Result{T}"/> instance based on the specified result.</returns>
    private Result<T> ConvertToNewResult<T>(Result<T> result)
    {
        result.SetTitle(Title);
        result.SetDetail(Detail);
        result.SetType(Type);
        result.SetStatusCode(StatusCode);
        result.AddMessageResult(_messages);

        return result;
    }

    /// <summary>
    /// Adds a message to the internal collection of messages.
    /// </summary>
    /// <remarks>Initializes the message collection if it is not already initialized.</remarks>
    /// <param name="item">The message result to add. Cannot be null.</param>
    private void AddMessageResult(MessageResult? item)
    {
        if (item is not null)
        {
            _messages ??= [];
            _messages.Add(item);
        }
    }

    /// <summary>
    /// Adds a collection of <see cref="MessageResult"/> items to the internal message list.
    /// </summary>
    /// <remarks>If the internal message list is null, it will be initialized before adding the
    /// items.</remarks>
    /// <param name="items">The collection of <see cref="MessageResult"/> items to add. This parameter cannot be null.</param>
    private void AddMessageResult(IEnumerable<MessageResult>? items)
    {
        if (items is not null)
        {
            _messages ??= [];
            _messages.AddRange(items);
        }
    }
}