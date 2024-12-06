namespace Tolitech.Results;

/// <summary>
/// Represents the result of an operation with optional metadata and messages.
/// </summary>
public class Result : IResult
{
    /// <summary>
    /// Represents a list of message results associated with the result.
    /// </summary>
    private readonly List<MessageResult> _messages = [];

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
    public IReadOnlyCollection<MessageResult> Messages => _messages;

    /// <summary>
    /// Gets a collection of error message results associated with the result.
    /// </summary>
    public IEnumerable<MessageResult> Errors => _messages.Where(x => x.Type == MessageType.Error);

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
    /// Represents a result indicating a bad request.
    /// </summary>
    /// <returns>An instance of the <see cref="Result"/> class indicating a bad request.</returns>
    public static Result BadRequest()
    {
        return new(false, StatusCode.BadRequest);
    }

    /// <summary>
    /// Represents a result indicating a bad request with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a bad request with the specified value.</returns>
    public static Result<T> BadRequest<T>(T value)
    {
        return new(value, false, StatusCode.BadRequest);
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
    /// Represents a result indicating forbidden access with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating forbidden access with the default value for type <typeparamref name="T"/>.</returns>
    public static Result<T> Forbidden<T>()
    {
        return new(false, StatusCode.Forbidden);
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
    /// Represents a result indicating a resource not found with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a resource not found with the specified value.</returns>
    public static Result<T> NotFound<T>(T value)
    {
        return new(value, false, StatusCode.NotFound);
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
    /// Represents a result indicating a conflict with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating a conflict with the specified value.</returns>
    public static Result<T> Conflict<T>(T value)
    {
        return new(value, false, StatusCode.Conflict);
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
    /// Represents a result indicating an internal server error with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating an internal server error with the specified value.</returns>
    public static Result<T> InternalServerError<T>(T value)
    {
        return new(value, false, StatusCode.InternalServerError);
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
    /// Represents a result indicating that the service is currently unavailable with a typed value.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="value">The typed value.</param>
    /// <returns>An instance of the <see cref="Result{T}"/> class indicating that the service is currently unavailable with the specified value.</returns>
    public static Result<T> ServiceUnavailable<T>(T value)
    {
        return new(value, false, StatusCode.ServiceUnavailable);
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
        _messages.Add(MessageResult.Information(_contextName, key, message));
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
        _messages.Add(MessageResult.Warning(_contextName, key, message));
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

        _messages.Add(ErrorResult.Create(_contextName, key, message, exception));
    }

    /// <summary>
    /// Adds messages from the provided result to the internal message collection.
    /// </summary>
    /// <param name="result">An instance of the interface IResult containing messages to be added.</param>
    public void AddMessages(IResult result)
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

            _messages.AddRange(result.Messages);
        }
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
        return statusCode is StatusCode.OK or StatusCode.Created or StatusCode.Accepted or StatusCode.NoContent;
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

        result._messages.AddRange(_messages);

        return result;
    }
}